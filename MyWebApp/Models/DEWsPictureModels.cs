using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(50)]
        [Display(Name = "제목")]
        [Column("TITLE")]
        [DataType(DataType.Text)]
        public string Title { get; set;}

        [Required]
        [Column("CONTENT")]
        [Display(Name = "공지사항 내용")]
        [DataType(DataType.Text)]
        public string Content { get; set; }

        [Column("WRITEDATE")]
        [DataType(DataType.Date )]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [Display(Name = "날짜")]
        public DateTime WriteDate { get; set; }

        [Column("WRITER")]
        [DataType(DataType.Text)]
        [Display(Name = "글쓴이")]
        public string Writer { get; set; }
    }
}