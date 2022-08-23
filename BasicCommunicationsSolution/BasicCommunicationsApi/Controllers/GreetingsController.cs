using Microsoft.AspNetCore.Mvc;

namespace BasicCommunicationsApi.Controllers;

public class GreetingsController : ControllerBase
{

    // GET /greeting
    [HttpGet("/greeting")]
    public ActionResult<GreetingResponse> GetTheGreeting()
    {
        var response = new GreetingResponse("Hello From the API!", DateTime.Now);
        return Ok(response); // 200 Ok
    }
}

public record GreetingResponse(string Greeting, DateTime WhenCreated);