using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Meals.API.Controllers;

[ApiController]
[Route("meals")]
public class MealsController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}