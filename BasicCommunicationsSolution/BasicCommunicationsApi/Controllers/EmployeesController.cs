using Microsoft.AspNetCore.Mvc;

namespace BasicCommunicationsApi.Controllers;

[Route("/employees")]
public class EmployeesController : ControllerBase
{
    // GET /employees/bob-smith

    [HttpGet("{employeeId}")]
    public ActionResult GetEmployeeById(string employeeId)
    {
        return Ok($"Getting you information about {employeeId}");
    }

    [HttpGet]
    public ActionResult GetAllEmployees([FromQuery] string department = "All")
    {
        return Ok($"We have one bazillion employees! You are seeing {department}");
    }
}
