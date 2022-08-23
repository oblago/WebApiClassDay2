using Microsoft.AspNetCore.Mvc;

namespace BasicCommunicationsApi.Controllers;

public class BlogController : ControllerBase
{
    [HttpGet("/blogs/{year:int}/{month:int:range(1,12)}/{day:int}")]
    public ActionResult GetBlogs(int year, int month, int day, 
        [FromHeader( Name ="User-Agent")] string userAgent)
    {
        if(month == 2 && day > 28)
        {
            return NotFound();
        }
        return Ok($"Showing blogs on {year}/{month}/{day} you are running {userAgent}");
    }
}
