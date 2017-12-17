namespace Web_HoangHiep.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TacGia")]
    public partial class TacGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TacGia()
        {
            ThamGias = new HashSet<ThamGia>();
        }

        [Key]
        public int MaTacGia { get; set; }

        [StringLength(50)]
        public string TenTacGia { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [Column(TypeName = "ntext")]
        public string TieuSu { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGia> ThamGias { get; set; }
    }
}