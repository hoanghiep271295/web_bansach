using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Admin
{
    public class SachDao
    {
        private MyDBContext db = null;

        public SachDao()
        {
            db = new MyDBContext();
        }

        public int Insert(Sach sach)
        {
            db.Saches.Add(sach);
            db.SaveChanges();
            return sach.MaSach;
        }

        public IEnumerable<Sach> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Sach> model = db.Saches;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenSach.Contains(searchString));
            }
            return model.OrderBy(n => n.MaSach).ToPagedList(page, pageSize);
        }

        public Sach getByID(int id)
        {
            return db.Saches.SingleOrDefault(x => x.MaSach == id);
        }

        public Sach ViewDetails(int id)
        {
            return db.Saches.Find(id);
        }

        public bool Update(Sach entity)
        {
            try
            {
                var sach = db.Saches.Find(entity.MaSach);
                sach.TenSach = entity.TenSach;
                sach.GiaBan = entity.GiaBan;
                sach.NgayCapNhat = entity.NgayCapNhat;
                sach.MaChuDe = entity.MaChuDe;
                sach.MaNXB = entity.MaNXB;
                sach.MoTa = entity.MoTa;
                sach.AnhBia = entity.AnhBia;
                sach.Moi = entity.Moi;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Sach sach = db.Saches.Find(id);
                db.Saches.Remove(sach);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write("Loi" + ex.Message + "nay dan xay ra");
            }
        }

        public bool CheckSach(string tensach)
        {
            var sach = db.Saches.SingleOrDefault(n => n.TenSach == tensach);
            if (sach == null)
            {
                return true;
            }
            else
                return false;
        }
    }
}