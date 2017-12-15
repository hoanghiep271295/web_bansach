using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_HoangHiep.Models.LoginModelClient
{
    public class ProductViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string AnhBia { set; get; }
        public decimal? Price { set; get; }
        public string CateName { set; get; }
        public DateTime? CreatedDate { set; get; }
    }
}