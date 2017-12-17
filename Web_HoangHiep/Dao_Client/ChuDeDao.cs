using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class ChuDeDao
    {
        private MyDBContext db = null;

        public ChuDeDao()
        {
            db = new MyDBContext();
        }

        public IQueryable<Sach> ListAllPaging(int machude)
        {
            return db.Saches.Where(x => x.MaChuDe == machude).OrderBy(n => n.MaSach);
        }

        public ChuDe ViewDetail(long id)
        {
            return db.ChuDes.Find(id);
        }
    }
}