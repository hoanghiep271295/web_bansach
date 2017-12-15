using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class NhaXuatBanDao
    {
        MyDBContext db = null;
        public NhaXuatBanDao()
        {

            db = new MyDBContext();
        }
        public IQueryable<Sach> SachTheoNXB(int maNXB)
        {
            return db.Saches.Where(n => n.MaNXB == maNXB).OrderByDescending(n => n.GiaBan); 

        }

    }
}