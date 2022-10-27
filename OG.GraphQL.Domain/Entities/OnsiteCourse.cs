using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OG.GraphQL.Domain.Entities
{
    [Table("OnsiteCourse")]
    public partial class OnsiteCourse
    {
        [Key]
        [Column("CourseID")]
        public int CourseId { get; set; }
        [StringLength(50)]
        public string Location { get; set; } = null!;
        [StringLength(50)]
        public string Days { get; set; } = null!;
        [Column(TypeName = "smalldatetime")]
        public DateTime Time { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("OnsiteCourse")]
        public virtual Course Course { get; set; } = null!;
    }
}
