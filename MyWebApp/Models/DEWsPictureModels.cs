
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MyWebApp.Models
{
    public class DEWsPictureModels
    {
        [Key]
        [Column("SEQ")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "글번호")]
        public int Seq { get; set; }
        
        [Required]
        [Column("IMAGE", TypeName = "Image")]
        [Display(Name = "청년부 사진")]
        public byte[] Content { get; set; }

        [Required]
        [Column("IMAGE_TYPE")]
        [DataType(DataType.Text)]
        public string ContentType { get; set; }
    }


    public class DEWsPictureViewModels
    {
        public HttpPostedFile Content { get; set; }
    }
}