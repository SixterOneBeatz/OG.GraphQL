using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OG.GraphQL.Domain.Entities
{
    [Table("StudentGrade")]
    public partial class StudentGrade
    {
        [Key]
        [Column("EnrollmentID")]
        public int EnrollmentId { get; set; }
        [Column("CourseID")]
        public int CourseId { get; set; }
        [Column("StudentID")]
        public int StudentId { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? Grade { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("StudentGrades")]
        public virtual Course Course { get; set; } = null!;
        [ForeignKey("StudentId")]
        [InverseProperty("StudentGrades")]
        public virtual Person Student { get; set; } = null!;
    }
}
