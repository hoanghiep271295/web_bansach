using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Admin
{
    public class LoginDao
    {
        private MyDBContext db = null;

        public LoginDao()
        {
            db = new MyDBContext();
        }

        public bool CheckLogin(KhachHang login)
        {
            var model = db.KhachHangs.SingleOrDefault(x => x.TaiKhoan == login.TaiKhoan && x.MatKhau == login.MatKhau);
            if (model == null)
                return true;
            else
                return false;
        }
    }
}