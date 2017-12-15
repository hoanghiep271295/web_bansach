using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_HoangHiep.Models;


namespace Web_HoangHiep.DAO
{
    public class LoginDao
    {
        MyDBContext db = null;
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