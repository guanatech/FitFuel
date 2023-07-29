using Fitfuel.Shared.Presentation;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitFuel.OAuth.OpenIddict.ResourceServer.Controllers;

[Route("resources")]
public class ResourceController : ApiController
{
    
    public ResourceController(IMapper mapper) : base(mapper)
    {
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetSecretResources()
    {
        var user = HttpContext.User?.Identity?.Name;
        return Ok($"user: {user}");
    }
}