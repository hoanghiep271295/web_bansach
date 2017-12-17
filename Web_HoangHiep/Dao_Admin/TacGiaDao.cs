using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Admin
{
    public class TacGiaDao
    {
        private MyDBContext db = null;

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
            try
            {
                TacGia tacgia = db.TacGias.Find(id);
                db.TacGias.Remove(tacgia);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write("Loi" + ex.Message + "nay dan xay ra");
            }
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
        /// <summary>
        /// kiểm tra trước khi xóa 1 bản ghi
        /// </summary>
        /// <param name="machude"></param>
        /// <returns></returns>
        public bool CheckTacGiaBeforeDelete(int id)
        {
            List<ThamGia> listsach = db.ThamGias.Where(n => n.MaTacGia == id).ToList();
            //tồn tại khóa ngoại nên không cho phép xóa
            //cách này hơi ngu nhưng không sao
            if (listsach.Count > 0)
            {
                return false;
            }
            else
                return true;
        }
    }
}