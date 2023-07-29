using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;
using OpenIddict.Abstractions;

namespace Fitfuel.OAuth.OpenIddict.AuthServer.Common.Interfaces;

public interface IAuthService
{
    IDictionary<string, StringValues> ParseOAuthParameters(HttpContext httpContext, List<string>? excluding = null);
    string BuildRedirectUrl(HttpRequest request, IDictionary<string, StringValues> oAuthParameters);
    bool IsAuthenticated(AuthenticateResult authenticateResult, OpenIddictRequest request);
}