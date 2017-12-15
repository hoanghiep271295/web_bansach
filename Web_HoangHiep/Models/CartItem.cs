using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_HoangHiep.Models;
namespace Web_HoangHiep.Models
{
    //[Serializable]
    public class CartItem
    {
        public Sach Sach { get; set; }
        public int SoLuong { get; set; }

    }
}