using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MyWebApp.Models
{
    public class ImageViewModel
    {
        [Required]
        public string Title { get; set; }

        public string AltText { get; set; }

        [DataType(DataType.Html)]
        public string Caption { get; set; }

        [DataType(DataType.Upload)]
        HttpPostedFileBase ImageUpload { get; set; }
    }

    public class MemberInfo
    {
        /// <summary>
        /// 이메일(계정)
        /// </summary>
        [Key]
        [Column("EMAIL")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        /// <summary>
        /// 리더여부
        /// </summary>
        [Column("IS_LEADER")]
        [Display(Name = "리더여부")]
        public string IsLeader { get; set; }

        [Column("GROUP")]
        [DataType(DataType.Text)]
        [Display(Name = "12청년")]
        public string Group { get; set; }

        /// <summary>
        /// 사진
        /// </summary>
        [Column("PICTURE_URL")]
        [Display(Name = "사진")]
        [DataType(DataType.ImageUrl)]
        public string PictureURL { get; set; }
        

        //[Key]
        //[Column("SEQ")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Display(Name = "글번호")]
        //public int Seq { get; set; }

        //[Required]
        //[StringLength(50)]
        //[Display(Name = "제목")]
        //[Column("TITLE")]
        //[DataType(DataType.Text)]
        //public string Title { get; set; }

        //[Required]
        //[Column("CONTENT")]
        //[Display(Name = "공지사항 내용")]
        //[DataType(DataType.Text)]
        //public string Content { get; set; }

        //[Column("WRITEDATE")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        //[Display(Name = "날짜")]
        //public DateTime WriteDate { get; set; }

        //[Column("WRITER")]
        //[DataType(DataType.Text)]
        //[Display(Name = "글쓴이")]
        //public string Writer { get; set; }

    }
}