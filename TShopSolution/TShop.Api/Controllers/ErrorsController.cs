using Microsoft.AspNetCore.Mvc;

namespace TShop.Api.Controllers;

public class ErrorsController: ControllerBase
{
    [HttpGet("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}