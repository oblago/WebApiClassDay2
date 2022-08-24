using CoursesApi.Domain;
using MongoDB.Bson;

namespace CoursesApi.Controllers;

[ApiController]
public class CoursesController : ControllerBase
{

    private readonly CourseManager _courseManager;
    private readonly ILogger<CoursesController> _logger;

    public CoursesController(CourseManager courseManager, ILogger<CoursesController> logger)
    {
        _courseManager = courseManager;
        _logger = logger;
    }

    [HttpDelete("/courses/{courseId}")]
    public async Task<ActionResult> RemoveCourse(string courseId)
    {
        await _courseManager.RemoveCourseByIdAsync(courseId);
        return NoContent();
    }

    [HttpPost("/online-courses")]
    public async Task<ActionResult<CourseDetailsResponse>> AddCourseAsync(
        [FromBody] CourseCreateRequest request)
    {
        // 1 Validate it - if not good, return a 400.
        // 2. If it's good, do the side effect (save it, whatever)
        CourseDetailsResponse response = await _courseManager.AddOnlineCourseAsync(request);
        // 3. Return:
        //    - 201 Created Status Code
        //    - Add a header called "Location" which says where that new resource lives. (uri)
        //    - Include a copy of what they would get if they went to URL
        //    - Location: http://localhost:9090/courses/938938938

        return CreatedAtRoute("courses#getcoursebyid", new { courseId = response.Id }, response);
    }

    [HttpPost("/onprem-courses")]
    public async Task<ActionResult<CourseDetailsResponse>> AddOnPremCourseAsync(
    [FromBody] CourseCreateRequest request)
    {
        // 1 Validate it - if not good, return a 400.
        // 2. If it's good, do the side effect (save it, whatever)
        CourseDetailsResponse response = await _courseManager.AddOnPremCourseAsync(request);
        // 3. Return:
        //    - 201 Created Status Code
        //    - Add a header called "Location" which says where that new resource lives. (uri)
        //    - Include a copy of what they would get if they went to URL
        //    - Location: http://localhost:9090/courses/938938938

        return CreatedAtRoute("courses#getcoursebyid", new { courseId = response.Id }, response);
    }


    [HttpGet("/courses")]
    public async Task<ActionResult<CoursesResponse>> GetAllCoursesAsync(CancellationToken ct)
    {
        // WTCYWYH
        _logger.LogInformation("Getting all the courses");
        CoursesResponse response = await _courseManager.GetAllCoursesAsync(ct);
        _logger.LogInformation("The courses have been gotten");
        return Ok(response);

    }

    [HttpGet("/courses/{courseId:bsonid}", Name = "courses#getcoursebyid")]
    public async Task<ActionResult<CourseDetailsResponse>> GetCourseByIdAsync(string courseId)
    {
        CourseDetailsResponse? response = await _courseManager.GetCourseByIdAsync(ObjectId.Parse(courseId));

        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }
}