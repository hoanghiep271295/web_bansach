using System;
using System.ComponentModel.DataAnnotations;

namespace Web_HoangHiep.Areas.Admin.Models
{
    [Serializable]
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Mời nhập password")]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}