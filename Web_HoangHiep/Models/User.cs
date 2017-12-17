namespace Web_HoangHiep.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}