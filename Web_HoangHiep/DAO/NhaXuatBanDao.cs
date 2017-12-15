using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using Web_HoangHiep.Models;


namespace Web_HoangHiep.DAO
{
   
        public class NhaXuatBanDao
        {
            MyDBContext db = null;

            public NhaXuatBanDao()
            {
                db = new MyDBContext();
            }
            public List<NhaXuatBan> listAllNXB()
            {
                return db.NhaXuatBans.ToList();
            }
        public int Insert(NhaXuatBan nxb)
        {
            db.NhaXuatBans.Add(nxb);
            db.SaveChanges();
            return nxb.MaNXB;
        }
         public IEnumerable<NhaXuatBan> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<NhaXuatBan> model = db.NhaXuatBans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenNXB.Contains(searchString) || x.DiaChi.Contains(searchString));
            }
            return model.OrderBy(n => n.MaNXB).ToPagedList(page, pageSize);
        }


        public bool Update(NhaXuatBan entity)
        {
            try
            {
                NhaXuatBan nhaxuatban = db.NhaXuatBans.Find(entity.MaNXB);
                nhaxuatban.TenNXB = entity.TenNXB;
                nhaxuatban.DiaChi = entity.DiaChi;
                nhaxuatban.DienThoai = entity.DienThoai;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)

            {
                return false;
            }
        }
        public NhaXuatBan getByID(int ma)
        {
            return db.NhaXuatBans.SingleOrDefault(x => x.MaNXB == ma); 
        }
       public NhaXuatBan ViewDetails(int ID)
        {
            return db.NhaXuatBans.Find(ID);
        }

    

        public bool Delete(int id)
        {
            try
            {
                NhaXuatBan nxb = db.NhaXuatBans.Find(id);
                db.NhaXuatBans.Remove(nxb);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.Write("Loi" + ex.Message + "nay dan xay ra");
                return false;
            }
        }
        public bool CheckNXB(string tenNXB)
        {
            var model = db.NhaXuatBans.SingleOrDefault(n => n.TenNXB == tenNXB);
            if (model == null)
            {
                return true;

            }
            else
                return false;
        }
    }
}