using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Admin
{
    public class HoaDonDao
    {
        private MyDBContext db = null;

        public HoaDonDao()
        {
            db = new MyDBContext();
        }

        public IEnumerable<DonHang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<DonHang> model = db.DonHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MaDonHang.ToString().Contains(searchString) || x.MaKH.ToString().Contains(searchString));
            }
            return model.OrderBy(n => n.MaDonHang).ToPagedList(page, pageSize);
        }

        public bool Update(DonHang entity)
        {
            try
            {
                var donhang = db.DonHangs.Find(entity.MaDonHang);

                donhang.NgayGiaoHang = entity.NgayGiaoHang;
                donhang.DaThanhToan = entity.DaThanhToan;
                donhang.TinhTrangGiaoHang = entity.TinhTrangGiaoHang;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Loi" + ex.Message + "dang xay ra");
                return false;
            }
        }

        public DonHang ViewDetails(int madonhang)
        {
            return db.DonHangs.Find(madonhang);
        }
    }
}