using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OG.GraphQL.Domain.Entities
{
    [Table("OfficeAssignment")]
    public partial class OfficeAssignment
    {
        [Key]
        [Column("InstructorID")]
        public int InstructorId { get; set; }
        [StringLength(50)]
        public string Location { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;

        [ForeignKey("InstructorId")]
        [InverseProperty("OfficeAssignment")]
        public virtual Person Instructor { get; set; } = null!;
    }
}
