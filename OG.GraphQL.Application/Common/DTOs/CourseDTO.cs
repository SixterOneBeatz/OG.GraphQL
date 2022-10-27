namespace OG.GraphQL.Application.Common.DTOs
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

    }
}
