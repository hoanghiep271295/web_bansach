using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.DAO
{
    public class ChuDeDao
    {
        MyDBContext db = null;

        public ChuDeDao()
        {
            db = new MyDBContext();
        }
        public List<ChuDe> listAllChuDe()
        {
            return db.ChuDes.ToList();
        }
        public bool CheckChuDe(string username)
        {
            var model = db.ChuDes.SingleOrDefault(x=>x.TenChuDe==username);
            if (model == null)
            {
                return true;
            }
            else
                return false;
         }
    }
}