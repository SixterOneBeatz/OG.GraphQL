using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OG.GraphQL.Domain.Entities
{
    [Table("Person")]
    public partial class Person
    {
        public Person()
        {
            StudentGrades = new HashSet<StudentGrade>();
            Courses = new HashSet<Course>();
        }

        [Key]
        [Column("PersonID")]
        public int PersonId { get; set; }
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EnrollmentDate { get; set; }
        [StringLength(50)]
        public string Discriminator { get; set; } = null!;

        [InverseProperty("Instructor")]
        public virtual OfficeAssignment? OfficeAssignment { get; set; }
        [InverseProperty("Student")]
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("People")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
