using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_HoangHiep.Models;
using PagedList;
using PagedList.Mvc;

namespace Web_HoangHiep.DAO
{
    public class KhachHangDao
    {
        MyDBContext db = null;
        public KhachHangDao()
        {
            db = new MyDBContext();
        }
        public int Insert(KhachHang kh)
        {
            db.KhachHangs.Add(kh);
            db.SaveChanges();
            return kh.MaKhacHang;
        }
        public IEnumerable<KhachHang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<KhachHang> model = db.KhachHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKhachHang.Contains(searchString) || x.TaiKhoan.Contains(searchString));
            }
            return model.OrderBy(n => n.MaKhacHang).ToPagedList(page, pageSize);
        }
        public bool Update(KhachHang entity)
        {
            try
            {
                var khachhang = db.KhachHangs.Find(entity.MaKhacHang);

                khachhang.TenKhachHang = entity.TenKhachHang;
                khachhang.MatKhau = entity.MatKhau;
                khachhang.DiaChi = entity.DiaChi;

                khachhang.NgaySinh = entity.NgaySinh;
                khachhang.GioiTinh = entity.GioiTinh;
                khachhang.Email = entity.Email;
                khachhang.DienThoai = entity.DienThoai;
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.Write("Loi" + ex.Message + "dang xay ra");
                return false;

            }
        }
        public KhachHang getByID(string taikhoan)
        {
            return db.KhachHangs.SingleOrDefault(x => x.TaiKhoan == taikhoan);
        }

        public KhachHang ViewDetails(int ID)
        {
            return db.KhachHangs.Find(ID);
        }

        public void Delete(int id)
        {


            KhachHang kh = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
     

        }
        public bool CheckKhachHang(string username,string password)
        {
            var model = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == username && n.MatKhau == password);
            if (model == null)
            {
                return true;
            }
            else
                return false;

        }
    }
}