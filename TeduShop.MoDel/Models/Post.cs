using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstract;

namespace TeduShop.Model.Models
{
    [Table("Posts")]
    public class Post : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { set; get; }

        public int CategogyID { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        [MaxLength(500)]
        public string Descreption { set; get; }

        [MaxLength(500)]
        public string Content { set; get; }

        public bool? HomeFlag { set; get; }
        public int? ViewCount { set; get; }
        public bool? HotFlag { set; get; }

        [ForeignKey("CategogyID")]
        public virtual PostCategory PostCategory { get; set; }
    }
}