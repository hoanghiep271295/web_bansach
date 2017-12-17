using System;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Dao_Client
{
    public class ChiTietDonHangDao
    {
        private MyDBContext db = null;

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
            catch (Exception ex)
            {
                Console.WriteLine("Error here" + ex.Message);
                return false;
            }
        }
    }
}