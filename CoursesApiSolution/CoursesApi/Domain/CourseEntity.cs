using MongoDB.Bson;

namespace CoursesApi.Domain
{
    public class CourseEntity
    {
        public ObjectId Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public decimal NumberOfHours { get; set; }
        public DeliveryLocationTypes DeliveryLocation { get; set; }
        public DateTime WhenCreated { get; set; } = DateTime.Now;
        //public InstructorInfo? Instructor { get; set; }
        public bool IsRemoved  { get; set; }   =   false;
    }

    public class InstructorInfo
    {
        
        public string Name { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;

    }
}
