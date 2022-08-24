using CoursesApi.Domain;
using MongoDB.Driver;

namespace CoursesApi.Adapters;

public class MongoDbCoursesAdapter
{
    private readonly IMongoCollection<CourseEntity> _coursesCollection;

    public MongoDbCoursesAdapter(string connectionString)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("courses_db");
        _coursesCollection = database.GetCollection<CourseEntity>("courses");
    }
    public IMongoCollection<CourseEntity> Courses { get { return _coursesCollection; } }
}