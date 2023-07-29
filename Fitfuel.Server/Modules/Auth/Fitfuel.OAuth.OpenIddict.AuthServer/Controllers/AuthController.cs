using System.Collections.Immutable;
using System.Security.Claims;
using System.Web;
using Fitfuel.OAuth.OpenIddict.AuthServer.Common.Constants;
using Fitfuel.OAuth.OpenIddict.AuthServer.Common.Interfaces;
using Fitfuel.OAuth.OpenIddict.AuthServer.Services;
using Fitfuel.Shared.Presentation;
using MapsterMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace FitFuel.OAuth.OpenIddict.AuthServer.Controllers;

[Route("auth")]
public class AuthController : ApiController
{
    
    private readonly IOpenIddictApplicationManager _applicationManager;
    private readonly IOpenIddictScopeManager _scopeManager;
    private readonly IAuthService _authService;
    
    public AuthController(
        IMapper mapper,
        IAuthService authService,
        IOpenIddictScopeManager scopeManager, 
        IOpenIddictApplicationManager applicationManager) 
        : base(mapper)
    {
        _authService = authService;
        _scopeManager = scopeManager;
        _applicationManager = applicationManager;
    }
    
    [HttpPost("~/connect/authorize")]
    public async Task<IActionResult> Authorize()
        {
            var request = HttpContext.GetOpenIddictServerRequest() ??
                          throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            var parameters = _authService.ParseOAuthParameters(HttpContext, new List<string> { OpenIddictConstants.Parameters.Prompt });

            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!_authService.IsAuthenticated(result, request))
            {
                return Challenge(properties: new AuthenticationProperties
                {
                    RedirectUri = _authService.BuildRedirectUrl(HttpContext.Request, parameters)
                }, new[] { CookieAuthenticationDefaults.AuthenticationScheme });
            }

            var application = await _applicationManager.FindByClientIdAsync(request.ClientId) ??
                              throw new InvalidOperationException("Details concerning the calling client application cannot be found.");

            var consentType = await _applicationManager.GetConsentTypeAsync(application);

            // we just ignore other consent types, because they are not compliant with OAuth and OpenId Connect docs, that state that Resource Owner should grant the Client access
            // you might also support Implicit ConsentType - where you do not require consent screen even if `prompt=consent` provided. In that case just drop this if.
            // you might want to support External ConsentType - where you need to get created authorization first by admin to be able to log in.
            if (consentType != OpenIddictConstants.ConsentTypes.Explicit)
            {
                return Forbid(
                    authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                    properties: new AuthenticationProperties(new Dictionary<string, string?>
                    {
                        [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidClient,
                        [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                            "Only explicit consent clients are supported"
                    }));
            }

            var consentClaim = result.Principal.GetClaim(Consts.ConsentNaming);

            // it might be extended in a way that consent claim will contain list of allowed client ids.
            if (consentClaim != Consts.GrantAccessValue)
            {
                var returnUrl = HttpUtility.UrlEncode(_authService.BuildRedirectUrl(HttpContext.Request, parameters));
                var consentRedirectUrl = $"/Consent?returnUrl={returnUrl}";

                return Redirect(consentRedirectUrl);
            }

            var userId = result.Principal.FindFirst(ClaimTypes.Email)!.Value;

            var identity = new ClaimsIdentity(
                authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                nameType: OpenIddictConstants.Claims.Name,
                roleType: OpenIddictConstants.Claims.Role);

            identity.SetClaim(OpenIddictConstants.Claims.Subject, userId)
                .SetClaim(OpenIddictConstants.Claims.Email, userId)
                .SetClaim(OpenIddictConstants.Claims.Name, userId)
                .SetClaims(OpenIddictConstants.Claims.Role, new List<string> { "user", "admin" }.ToImmutableArray());

            identity.SetScopes(request.GetScopes());
            identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListAsync());

            identity.SetDestinations(c => AuthService.GetDestinations(identity, c));

            return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
    
    [HttpPost("~/connect/token")]
        public async Task<IActionResult> Exchange()
        {
            var request = HttpContext.GetOpenIddictServerRequest() ??
                          throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            if (!request.IsAuthorizationCodeGrantType() && !request.IsRefreshTokenGrantType())
                throw new InvalidOperationException("The specified grant type is not supported.");

            var result =
                await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            var userId = result.Principal.GetClaim(Claims.Subject);

            if (string.IsNullOrEmpty(userId))
            {
                return Forbid(
                    authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                    properties: new AuthenticationProperties(new Dictionary<string, string?>
                    {
                        [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
                        [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                            "Cannot find user from the token."
                    }));
            }

            var identity = new ClaimsIdentity(result.Principal.Claims,
                authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                nameType: Claims.Name,
                roleType: Claims.Role);

            identity.SetClaim(Claims.Subject, userId)
                .SetClaim(Claims.Email, userId)
                .SetClaim(Claims.Name, userId)
                .SetClaims(Claims.Role, new List<string> { "user", "admin" }.ToImmutableArray());

            identity.SetDestinations(c => AuthService.GetDestinations(identity, c));

            return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        [HttpPost("~/connect/logout")]
        public async Task<IActionResult> LogoutPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return SignOut(
                authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                properties: new AuthenticationProperties
                {
                    RedirectUri = "/"
                });
        }
}