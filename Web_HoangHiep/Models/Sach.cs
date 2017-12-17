namespace Web_HoangHiep.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            ThamGia = new HashSet<ThamGia>();
        }

        [Key]
        public int MaSach { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        public decimal? GiaBan { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [StringLength(100)]
        public string AnhBia { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? NgayCapNhat { get; set; }

        public int? SoLuongTon { get; set; }

        public int? MaChuDe { get; set; }

        public int? MaNXB { get; set; }

        public bool? Moi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual ChuDe ChuDe { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGia> ThamGia { get; set; }
    }
}