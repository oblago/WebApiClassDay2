using Microsoft.AspNetCore.Mvc;

namespace BasicCommunicationsApi.Controllers;

public class LongRunningController : ControllerBase
{
    [HttpGet("/longrunning")]
    public async Task<ActionResult> GetLongRunningThingAsync(CancellationToken ct)
    {
        
        try
        {
            Console.WriteLine("About to wait");
            await Task.Delay(3000, ct);
            Console.WriteLine("The Wait Is Over");
            return Ok("All Done!");
        }
        catch (TaskCanceledException)
        {

            Console.WriteLine("The async task was cancelled");
            return BadRequest("Request was cancelled via cancellation token");
        }
    }
}
