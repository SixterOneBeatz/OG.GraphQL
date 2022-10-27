using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OG.GraphQL.Domain.Entities
{
    [Table("OnlineCourse")]
    public partial class OnlineCourse
    {
        [Key]
        [Column("CourseID")]
        public int CourseId { get; set; }
        [Column("URL")]
        [StringLength(100)]
        public string Url { get; set; } = null!;

        [ForeignKey("CourseId")]
        [InverseProperty("OnlineCourse")]
        public virtual Course Course { get; set; } = null!;
    }
}
