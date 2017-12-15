using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.DAO
{
    public class TacGiaDao
    {
        MyDBContext db = null;
        public TacGiaDao()
        {
            db = new MyDBContext();
        }
        public int Insert(TacGia tacgia)
        {
            db.TacGias.Add(tacgia);
            db.SaveChanges();
            return tacgia.MaTacGia;
        }
        public IEnumerable<TacGia> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<TacGia> model = db.TacGias;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenTacGia.Contains(searchString) || x.TieuSu.Contains(searchString));
            }
            return model.OrderBy(n => n.MaTacGia).ToPagedList(page, pageSize);
        }

        public TacGia getByID(int id)
        {
            return db.TacGias.SingleOrDefault(x => x.MaTacGia == id);

        }
        public TacGia ViewDetails(int id)
        {
            return db.TacGias.Find(id);
        }

        public bool Update(TacGia entity)
        {
            try
            {
                var tacgia = db.TacGias.Find(entity.MaTacGia);
                tacgia.TenTacGia = entity.TenTacGia;
                tacgia.TieuSu = entity.TieuSu;
                tacgia.Email = entity.Email;
                tacgia.DiaChi = entity.DiaChi;
                tacgia.DienThoai = entity.DienThoai;
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
           
                TacGia tacgia = db.TacGias.Find(id);
                db.TacGias.Remove(tacgia);
                db.SaveChanges();
            

        }
        public bool CheckTacGia(string tentacgia, string email)
        {
            var model = db.TacGias.SingleOrDefault(n => n.TenTacGia == tentacgia && n.Email == email);
            if (model == null)
            {
                return true;
            }
            else

                return false;
        }
    }
}