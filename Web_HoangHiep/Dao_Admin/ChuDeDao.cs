using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Admin
{
    public class ChuDeDao
    {
        private MyDBContext db = null;

        public ChuDeDao()
        {
            db = new MyDBContext();
        }

        /// <summary>
        /// lấy danh sách để hiển thị lên combobox
        /// </summary>
        /// <returns></returns>
        public List<ChuDe> listAllChuDe()
        {
            return db.ChuDes.ToList();
        }
        /// <summary>
        /// lấy toàn bộ danh sách chủ đề
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ChuDe> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ChuDe> model = db.ChuDes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenChuDe.Contains(searchString));
            }
            return model.OrderBy(n => n.MaChuDe).ToPagedList(page, pageSize);
        }
        /// <summary>
        /// Kiểm tra sự tồn tại của chủ đề trước khi tiến hành thêm mới
        /// </summary>
        /// <param name="username">Tên chủ đề</param>
        /// <returns></returns>
        public bool CheckChuDe(string tenchude)
        {
            var model = db.ChuDes.SingleOrDefault(x => x.TenChuDe == tenchude);
            if (model == null)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// kiểm tra sự tồn tại của chủ đề này có khóa ngoại với sách không trước khi xóa
        /// </summary>
        /// <param name="machude">mã chủ đề</param>
        /// <returns></returns>
        public bool CheckChuDeBeforeDelete(int machude)
        {
            List<Sach> listsach = db.Saches.Where(n => n.MaChuDe == machude).ToList();
            //tồn tại sách có chủ đề này
            if (listsach.Count > 0)
            {
                return false;
            }
            //không tồn tại
            else
                return true;
        }

        /// <summary>
        /// xóa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteChuDe(int id)
        {
            try
            {
                if (CheckChuDeBeforeDelete(id))
                {
                    NhaXuatBan nxb = db.NhaXuatBans.Find(id);
                    db.NhaXuatBans.Remove(nxb);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                Console.Write("Loi" + ex.Message + "nay dan xay ra");
                return false;
            }
        }
        /// <summary>
        /// update chủ đề
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(ChuDe entity)
        {
            try
            {
                ChuDe chude = db.ChuDes.Find(entity.MaChuDe);
                chude.TenChuDe = entity.TenChuDe;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)

            {
                Console.WriteLine("Error here" + ex.Message);
                return false;
            }
        }

        public ChuDe getByID(int ma)
        {
            return db.ChuDes.SingleOrDefault(x => x.MaChuDe == ma);
        }

        public ChuDe ViewDetails(int ID)
        {
            return db.ChuDes.Find(ID);
        }

        public int Insert(ChuDe chude)
        {
            db.ChuDes.Add(chude);
            db.SaveChanges();
            return chude.MaChuDe;
        }

    }
}