using CoursesApi.Domain;
using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Models
{
    public record CourseSummaryItemResponse
    {
        public string Id { get; set; } = string.Empty;

        public string Title     { get; set; } = string.Empty ;
    }
    public record CoursesResponse
    {
        public List<CourseSummaryItemResponse> Data { get; init; } = new();
    }

    public record CourseDetailsResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal NumberOfHours { get; set; }
        public DeliveryLocationTypes DeliveryLocation { get; set; }
        public InstructorInfo? Instructor { get; set; }
    }



    public enum DeliveryLocationTypes
    {
        Online,
        OnPrem
    }
    public record CourseCreateRequest
    {
        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Range(1, 100)]
        public decimal NumberOfHours { get; set; }
        public DeliveryLocationTypes DeliveryLocation { get; set; }
    }


}
