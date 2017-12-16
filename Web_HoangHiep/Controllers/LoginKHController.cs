﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_HoangHiep.CommonSession;
using Web_HoangHiep.Dao_Client;
using Web_HoangHiep.Models;
using Web_HoangHiep.Models.LoginModelClient;


namespace Web_HoangHiep.Controllers
{
    public class LoginKHController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModelClient model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoginDaoClient();
                var result = dao.Check(model.taikhoan, model.password);

               if(result==false)
                {
                    ModelState.AddModelError("","Đăng Nhập Thất Bại");
                    return View("Login");
                }
               else
               if(result==true)
                {
                    var khachhang = new KhachhangDao().GetKhachhang(model.taikhoan, model.password);
                    Session["KhachHang"] = khachhang;
                    Session["UserName"] = khachhang.TenKhachHang;
                    return RedirectToAction("Index", "Home");

                }

            }
            else
            ModelState.AddModelError("", "Vui Lòng Đăng Nhập Đủ");

            return View("Index");
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy(KhachHang kh)
        {
            
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["KhachHang"] = null;
            Session[SessionCommand.SessionGioHang] = null;
            return RedirectToAction("/");
        }
    }
}