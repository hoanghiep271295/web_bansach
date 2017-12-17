using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class KhachhangDao
    {
        private MyDBContext db = null;

        public KhachhangDao()
        {
            db = new MyDBContext();
        }

        public bool CheckLogin(KhachHang kh)
        {
            var model = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == kh.TaiKhoan && n.MatKhau == kh.MatKhau);

            if (model == null)
            {
                return true;
            }
            else
                return false;
        }

        public bool InsertKH(KhachHang kh)
        {
            try
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangePass(string username, string oldpass, string newpass)
        {
            KhachHang kh = new KhachHang();
            var model = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == username && n.MatKhau == oldpass);
            if (model != null)
            {
                kh.MatKhau = newpass;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public KhachHang GetKhachhang(string username, string password)
        {
            return db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == username && n.MatKhau == password);
        }
        public KhachHang LoginGoogle(string socialId,string name,string email)
        {
            var model = db.KhachHangs.SingleOrDefault(n => n.SocialID == socialId);
            if (model == null)
            {
                KhachHang kh = new KhachHang(socialId, name, email);
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return kh;
            }
            else
                return model;
        }
    }
}