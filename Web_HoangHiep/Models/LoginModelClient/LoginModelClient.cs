using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_HoangHiep.Models.LoginModelClient
{
    public class LoginModelClient
    {
        [Required]
        [Key]
        [Display(Name ="Tài Khoản")]
        public string taikhoan { set; get; }
        [Required]
        [Display(Name ="Mật Khẩu")]
        public string password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}