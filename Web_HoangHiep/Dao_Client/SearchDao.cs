using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_HoangHiep.Models;
namespace Web_HoangHiep.Dao_Client
{
    public class SearchDao
    {
        MyDBContext db = null;
        public SearchDao()
        {
            db = new MyDBContext();
        }
        public List<Sach> TimKiem(string tukhoa)
        {
            List<Sach> model = db.Saches.Where(n => n.TenSach.Contains(tukhoa)).OrderBy(n=>n.TenSach).ToList() ;
            return model;
        }
    }
}