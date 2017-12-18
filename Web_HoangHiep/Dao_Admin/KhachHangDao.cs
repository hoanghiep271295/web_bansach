using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Admin
{
    public class KhachHangDao
    {
        private MyDBContext db = null;

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

        /// <summary>
        /// lấy khách hàng theo tên tài khoản đăng nhập
        /// </summary>
        /// <param name="taikhoan"></param>
        /// <returns></returns>
        public KhachHang getByTaiKhoan(string taikhoan)
        {
            return db.KhachHangs.SingleOrDefault(x => x.TaiKhoan == taikhoan);
        }
        /// <summary>
        /// view detail khách hàng
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        public KhachHang ViewDetails(int ID)
        {
            return db.KhachHangs.Find(ID);
        }
        /// <summary>
        /// Kiểm tra sự tồn tại của khách hàng bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KhachHang getById(int id)
        {
            return db.KhachHangs.SingleOrDefault(x => x.MaKhacHang == id);
        }


        /// <summary>
        /// xóa 1 khách hàng bởi id truyền vào
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                KhachHang kh = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(kh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write("Loi" + ex.Message + "nay dan xay ra");
            }
        }

        public bool CheckKhachHang(string username, string password)
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