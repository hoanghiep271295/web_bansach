using System.Collections.Generic;
using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class NhaXuatBanDao
    {
        private MyDBContext db = null;

        public NhaXuatBanDao()
        {
            db = new MyDBContext();
        }

        public IEnumerable<Sach> SachTheoNXB(int maNXB)
        {
            return db.Saches.Where(n => n.MaNXB == maNXB).OrderByDescending(n => n.GiaBan);
        }
    }
}