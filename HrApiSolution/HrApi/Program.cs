using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/course-instructors/{id}", (string id) =>
{
    var response = new InstructorInfo { Name = "Jeff Gonzales", EmailAddress = "jeff@hypertheory.com" };
    return Results.Ok(response);
});


app.Run();

public class InstructorInfo
{

    public string Name { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;

}