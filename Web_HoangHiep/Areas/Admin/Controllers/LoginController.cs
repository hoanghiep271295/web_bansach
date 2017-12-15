using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_HoangHiep.Areas.Admin.Models;
using Web_HoangHiep.DAO;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
         public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
       
                if (result==1)
                {
                    User user = dao.getUser(model.UserName, model.Password);
                    Session["User"] = user;
                    return RedirectToAction("Index","TrangChu");
                }
                else
                if(result==0)
                {
                    ViewBag.UserName = model.UserName;
                    ViewBag.Password = model.Password;
                    ModelState.AddModelError("", "Tài Khoản Chưa Tồn Tại");
                    return View();
                }
                else
                    if(result==-1)
                {
                    ViewBag.UserName = model.UserName;
                    ModelState.AddModelError("", "Sai Mật Khẩu");
                    return View();
                }
                    
            }
            ModelState.AddModelError("", "Vui Lòng Đăng Nhập Đủ");
           
            return View("Index");
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}