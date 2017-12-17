using System.ComponentModel.DataAnnotations;

namespace Web_HoangHiep.Models.LoginModelClient
{
    public class LoginModelClient
    {
        [Required]
        [Key]
        [Display(Name = "Tài Khoản")]
        public string taikhoan { set; get; }

        [Required]
        [Display(Name = "Mật Khẩu")]
        public string password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}