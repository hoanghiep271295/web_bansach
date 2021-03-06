﻿using System.Web.Mvc;
using Web_HoangHiep.Dao_Admin;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class TacGiaADController : Controller
    {
        // GET: Admin/TacGiaAD

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new TacGiaDao();
                ViewBag.SearchString = searchString;
                var model = dao.ListAllPaging(searchString, page, pageSize);

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Add(TacGia tacgia)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var model = new TacGiaDao().CheckTacGia(tacgia.TenTacGia, tacgia.Email);
                if (model == false)
                {
                    ModelState.AddModelError("", "Tác Giả Này Đã Tồn Tại");
                    return View("Add");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var dao = new TacGiaDao();
                        int id = dao.Insert(tacgia);
                        if (id > 0)
                        {
                            return RedirectToAction("Index", "TacGiaAD");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Thêm Mới Thất Bại");
                            return View("Add");
                        }
                    }
                }
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var nxb = new TacGiaDao().ViewDetails(id);
                return View(nxb);
            }
        }

        [HttpPost]
        public ActionResult Edit(TacGia tacgia)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var model = new TacGiaDao().CheckTacGia(tacgia.TenTacGia, tacgia.Email);
                if (model == false)
                {
                    ModelState.AddModelError("", "Tác Giả Này Đã Tồn Tại");
                    return View("Edit");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var dao = new TacGiaDao();
                        var result = dao.Update(tacgia);
                        if (result)
                        {
                            return RedirectToAction("Index", "TacGiaAD");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Cập Nhật Khách Hàng  Thất Bại");
                            return View("Edit");
                        }
                    }
                    return View("Index");
                }
            }
        }

        public ActionResult Delete(int ID)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                new TacGiaDao().Delete(ID);

                return RedirectToAction("Index");
            }
        }

        [HttpDelete]
        public ActionResult Delele(int ID)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                new TacGiaDao().Delete(ID);

                return RedirectToAction("Index");
            }
        }
    }
}