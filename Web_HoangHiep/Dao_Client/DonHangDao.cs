using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class DonHangDao
    {
        private MyDBContext db = null;

        public DonHangDao()
        {
            db = new MyDBContext();
        }

        public bool Insert(DonHang donhang)
        {
            try
            {
                db.DonHangs.Add(donhang);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool FindKhachHang(string name, string email)
        {
            var khachhang = db.KhachHangs.SingleOrDefault(x => x.TenKhachHang == name && x.Email == email);
            if (khachhang == null)
                return false;
            else
                return true;
        }
    }
}