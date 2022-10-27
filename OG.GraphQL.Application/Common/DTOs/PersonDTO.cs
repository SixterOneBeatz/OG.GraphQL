namespace OG.GraphQL.Application.Common.DTOs
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Discriminator { get; set; } = null!;
    }
}
