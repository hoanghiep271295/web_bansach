using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_HoangHiep.Models;
using PagedList;
using PagedList.Mvc;
using Web_HoangHiep.DAO;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            ViewBag.SearchString = searchString;
            var model = dao.ListAllPaging(searchString, page, pageSize);

            return View(model);
        }
        [HttpGet]
        public ActionResult SingIn()
        {

            return View();

        }
        [HttpPost]
        public ActionResult SingIn(User user)
        {

            var dao = new UserDao().CheckUser(user.UserName,user.Email);
            if (dao)
            {
                if (ModelState.IsValid)
                {
                    var a = new UserDao().Insert(user);
                    ViewBag.KQ = 1;
                    return RedirectToAction("Index");
                }

            }
            else
            {
                ViewBag.KQ = 0;
                ViewBag.ThongBao = "Tài Khoản Đã Tồn Tại";
            }

            ViewBag.UserName = user.UserName;
            ViewBag.Email = user.Email;
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new UserDao().ViewDeatis(id);
            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var dao = new UserDao();
            var model = dao.CheckLogin(user.UserName);
            if (model==false)
            {
                ModelState.AddModelError("", "Đã có Usrename này ");
                return View("Edit");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var result = dao.Update(user);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Chỉnh Sửa Thất Bại");
                        return View("Edit");
                    }
                }
                else
                    ModelState.AddModelError("", "Mời Nhập Đủ Các Trường");

            }
            return View("Index");
            

        }
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}