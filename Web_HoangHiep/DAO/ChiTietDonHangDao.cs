using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_HoangHiep.Models;
using PagedList;
using PagedList.Mvc;



namespace Web_HoangHiep.DAO
{
    public class ChiTietDonHangDao
    {

        MyDBContext db = null;
        public ChiTietDonHangDao()
        {
            db = new MyDBContext();
        }
        public IEnumerable<ChiTietDonHang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ChiTietDonHang> model = db.ChiTietDonHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MaDonHang.ToString().Contains(searchString) || x.MaSach.ToString().Contains(searchString));
            }
            return model.OrderBy(n => n.MaDonHang).ToPagedList(page, pageSize);
        }
        public ChiTietDonHang ViewDetails(int id)
        {

            return db.ChiTietDonHangs.Find(id);
        }
    }
}