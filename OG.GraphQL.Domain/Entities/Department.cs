using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OG.GraphQL.Domain.Entities
{
    [Table("Department")]
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
