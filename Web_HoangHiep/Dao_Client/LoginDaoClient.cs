using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class LoginDaoClient
    {
        MyDBContext db = null;
        public LoginDaoClient()

        {
            db = new MyDBContext();
        }

        public bool Check(string username, string password)
        {
            var result = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == username && n.MatKhau == password);
            if (result == null)
            {
                return false;
            }
            else
                return true;
        }
        public bool CheckKHTaiKhoan(string userName)
        {
            return db.KhachHangs.Count(x => x.TaiKhoan == userName) > 0;
        }
        public bool CheckKHEmail(string email)
        {
            return db.KhachHangs.Count(x => x.Email == email) > 0;
        }
    }
}