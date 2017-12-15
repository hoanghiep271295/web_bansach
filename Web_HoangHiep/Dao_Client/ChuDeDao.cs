using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Web_HoangHiep.Models;
using PagedList.Mvc;
using Web_HoangHiep.Models.LoginModelClient;

namespace Web_HoangHiep.Dao_Client
{
    public class ChuDeDao
    {

        MyDBContext db = null;
        public ChuDeDao()
        {

            db = new MyDBContext();
        }
        public IQueryable<Sach> ListAllPaging(int machude)
        {
            return db.Saches.Where(x => x.MaChuDe == machude).OrderBy(n=>n.MaSach);
        }



        public ChuDe ViewDetail(long id)
        {
            return db.ChuDes.Find(id);
        }
        public bool KiemTraChuDe(int machude)
        {
            List<Sach> listsach = db.Saches.Where(n => n.MaChuDe == machude).ToList();
            if (listsach.Count == 0)
            {
                return false;
            }
            else
                return true;

        }
    }
}