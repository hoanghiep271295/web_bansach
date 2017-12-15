using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_HoangHiep.Models;


namespace Web_HoangHiep.Dao_Client
{

    public class QuanLySachDao
    {
        MyDBContext db = null;
        public QuanLySachDao()
        {
            db = new MyDBContext();
        }
        public List<Sach> listSachMoi()
        {
            return db.Saches.Where(n=>n.Moi==true).OrderByDescending(n=>n.SoLuongTon).Take(8).ToList();
        }
        public List<NhaXuatBan> listNXB()
        {
            return db.NhaXuatBans.OrderBy(x => x.MaNXB).ToList();
        }
        public List<TacGia> listTacGia()
        {
            return db.TacGias.OrderBy(x => x.MaTacGia).ToList();
        }
        public List<ChuDe> listChuDe()
        {
            return db.ChuDes.OrderBy(n => n.TenChuDe).ToList();
        }
    }
}