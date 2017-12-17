using System;
using System.ComponentModel.DataAnnotations;

namespace Web_HoangHiep.Models.LoginModelClient
{
    public class ProductViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string AnhBia { set; get; }

        public decimal? Price { set; get; }

        public string CateName { set; get; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? CreatedDate { set; get; }
    }
}