using PagedList;
using System.Collections.Generic;
using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class SachDao
    {
        private MyDBContext db = null;

        public SachDao()
        {
            db = new MyDBContext();
        }

        public List<Sach> ListSachMoi()
        {
            return db.Saches.Where(n => n.Moi == true).OrderBy(n => n.MaSach).ToList();
        }

        public IEnumerable<Sach> ListAllSach(int page, int pageSize)
        {
            return db.Saches.OrderByDescending(n => n.GiaBan).ToPagedList(page, pageSize);
        }

        public Sach ViewDetails(int id)
        {
            return db.Saches.Find(id);
        }

        public List<Sach> listNewSach(int top)
        {
            return db.Saches.OrderByDescending(x => x.NgayCapNhat).Take(top).ToList();
        }

        public List<Sach> listFeatureSach(int top)
        {
            return db.Saches.OrderByDescending(x => x.GiaBan).Take(top).ToList();
        }

        public List<Sach> SpecialBook(int top)
        {
            return db.Saches.Where(n => n.Moi == true).OrderBy(x => x.GiaBan).Take(top).ToList();
        }

        public Sach Details(int id)
        {
            return db.Saches.Find(id);
        }

        public List<Sach> ListRelate(int productID)
        {
            var sach = db.Saches.Find(productID);
            return db.Saches.Where(x => x.MaSach != productID && x.MaChuDe == sach.MaChuDe).ToList();
        }

        public List<Sach> SieuPham()
        {
            return db.Saches.OrderBy(n => n.GiaBan).Take(1).ToList();
        }

        public bool CheckSack(int masach)
        {
            var model = db.Saches.SingleOrDefault(n => n.MaSach == masach);
            if (model == null)
                return false;
            else
                return true;
        }

        public int Soluong()
        {
            var a = new Sach();
            int? model = 0;

            for (int i = 0; i < a.MaSach; i++)
            {
                model = model + a.SoLuongTon;
            }
            return model.Value;
        }

        public List<Sach> NewBook()
        {
            return db.Saches.Where(n => n.Moi == true).OrderBy(n => n.TenSach).ToList();
        }
    }
}