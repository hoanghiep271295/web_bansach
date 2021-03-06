﻿using System.Collections.Generic;
using System.Web.Mvc;
using Web_HoangHiep.CommonSession;
using Web_HoangHiep.Dao_Client;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            var dao = new SachDao();
            ViewBag.NewProduct = dao.listNewSach(3);
            ViewBag.FeatureProduct = dao.listFeatureSach(3);
            ViewBag.SpecialProduct = dao.SpecialBook(2);
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration =3600, VaryByParam = "*")]
        public ActionResult Slide()
        {
            var dao = new QuanLySachDao().listSachMoi();
            return PartialView(dao);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[SessionCommand.SessionGioHang];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult SlideBarLeft()
        {
            var model = new QuanLySachDao().listChuDe();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult SlideBarNhaXuatBan()
        {
            var model = new QuanLySachDao().listNXB();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult SlideBarTacGia()
        {
            var model = new QuanLySachDao().listTacGia();
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Contact()
        {
         
            return View();
        }
    }
}