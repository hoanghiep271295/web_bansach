using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class TacGiaDao
    {
        private MyDBContext db = null;

        public TacGiaDao()
        {
            db = new MyDBContext();
        }

        public TacGia ViewDetails(int matacgia)
        {
            return db.TacGias.Find(matacgia);
        }

        public IQueryable<Sach> listSach_TacGia(int id)
        {
            var result = (from tg in db.TacGias
                          join st in db.ThamGias on tg.MaTacGia equals st.MaTacGia
                          join s in db.Saches on st.MaSach equals s.MaSach
                          where tg.MaTacGia == id
                          select s);
            return result.OrderBy(n => n.GiaBan);
        }
    }
}