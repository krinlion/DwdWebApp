using System;
using System.Collections.Generic;
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

        [Column("NAME")]
        [Display(Name = "이름")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        /// <summary>
        /// 사진
        /// </summary>
        [Display(Name = "사진")]
        [Column("PICTURE", TypeName = "Image")]
        public byte[] Picture { get; set; }

        [Column("PictureType")]
        [DataType(DataType.Text)]
        public string PictureType { get; set; }

        /// <summary>
        /// 설명
        /// </summary>
        [Column("DESCRIPTION")]
        [Display(Name = "설명")]
        [DataType(DataType.ImageUrl)]
        public string Description { get; set; }

        /// <summary>
        /// 리더 계정
        /// </summary>
        [Column("LEADER_EMAIL")]
        [DataType(DataType.EmailAddress)]
        public string LeaderEmail { get; set; }

        /// <summary>
        /// 전화번호
        /// </summary>
        [Column("PHONE_NUMBER")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 관리자여부
        /// </summary>
        [Column("IS_ADMIN")]
        public bool IsAdmin { get; set; }
    }

    public class MemberInfoViewModel
    {
        /// <summary>
        /// 이메일(계정)
        /// </summary>
        public string Email { get; set; }

        [Display(Name = "리더여부")]
        public bool IsLeader { get; set; }

        [Display(Name = "12청년")]
        public string Group { get; set; }

        
        [Display(Name = "이름")]
        public string Name { get; set; }

        /// <summary>
        /// 사진
        /// </summary>
        [Display(Name = "사진")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase PictureURL { get; set; }

        /// <summary>
        /// 설명
        /// </summary>
        [Display(Name = "설명")]
        public string Description { get; set; }
        
        /// <summary>
        /// 전화번호
        /// </summary>
        [Display(Name = "전화번호")]
        public string PhoneNumber { get; set; }

        [Display(Name = "리더 계정")]
        public string LeaderEmail { get; set; }
    }
}