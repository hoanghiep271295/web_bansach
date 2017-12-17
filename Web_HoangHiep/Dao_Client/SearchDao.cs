using System.Collections.Generic;
using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class SearchDao
    {
        private MyDBContext db = null;

        public SearchDao()
        {
            db = new MyDBContext();
        }

        public List<Sach> TimKiem(string tukhoa)
        {
            List<Sach> model = db.Saches.Where(n => n.TenSach.Contains(tukhoa)).OrderBy(n => n.TenSach).ToList();
            return model;
        }

        public List<NhaXuatBan> TimKiemNhaXuatBan(string tukhoa)
        {
            List<NhaXuatBan> nhaxuatbans = db.NhaXuatBans.Where(n => n.TenNXB.Contains(tukhoa)).OrderBy(n => n.MaNXB).ToList();
            return nhaxuatbans;
        }

        public List<TacGia> TimKiemTacGia(string tukhoa)
        {
            List<TacGia> tacgias = db.TacGias.Where(n => n.TenTacGia.Contains(tukhoa)).OrderBy(n => n.MaTacGia).ToList();
            return tacgias;
        }




    }
}