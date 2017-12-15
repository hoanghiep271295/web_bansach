using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_HoangHiep.Models;
using Web_HoangHiep.Dao_Client;

namespace Web_HoangHiep.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang kh )
        {
            var model = new KhachhangDao().CheckLogin(kh);
            return View();
        }
    }
}