using CoursesApi.Domain;

namespace CoursesApi.Adapters;

public class HrApiAdapter
{
    private readonly HttpClient _httpClient;

    public HrApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<InstructorInfo?> GetInstructorInfoForCourseAsync(string courseId)
    {
        var response = await _httpClient.GetAsync($"/course-instructors/{courseId}");

        response.EnsureSuccessStatusCode(); // If it is 200-299, fine. Anything esle? Blamo!

        var content = await response.Content.ReadFromJsonAsync<InstructorInfo>();
        return content;
    }
}