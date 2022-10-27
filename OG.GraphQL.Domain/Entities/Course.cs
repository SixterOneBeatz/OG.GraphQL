using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OG.GraphQL.Domain.Entities
{
    [Table("Course")]
    public partial class Course
    {
        public Course()
        {
            StudentGrades = new HashSet<StudentGrade>();
            People = new HashSet<Person>();
        }

        [Key]
        [Column("CourseID")]
        public int CourseId { get; set; }
        [StringLength(100)]
        public string Title { get; set; } = null!;
        public int Credits { get; set; }
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("Courses")]
        public virtual Department Department { get; set; } = null!;
        [InverseProperty("Course")]
        public virtual OnlineCourse? OnlineCourse { get; set; }
        [InverseProperty("Course")]
        public virtual OnsiteCourse? OnsiteCourse { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("Courses")]
        public virtual ICollection<Person> People { get; set; }
    }
}
