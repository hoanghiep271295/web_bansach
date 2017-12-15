using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_HoangHiep.Models;
namespace Web_HoangHiep.Dao_Client
{
    public class ChiTietDonHangDao
    {
        MyDBContext db = null;
        public ChiTietDonHangDao()
        {
            db = new MyDBContext();
        }
        public bool Insert(ChiTietDonHang chitiet)           
        {
            try
            {
                db.ChiTietDonHangs.Add(chitiet);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}