using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Web_HoangHiep.Models;
using Web_HoangHiep.DAO;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class NhaXuatBanADController : BaseController
    {
        // GET: Admin/NhaXuatBanAD

      
        public ActionResult Index(string searchString,int page=1,int pageSize=10)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new NhaXuatBanDao();
                ViewBag.SearchString = searchString;
                var model = dao.ListAllPaging(searchString, page, pageSize);

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(NhaXuatBan nxb)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var model = new NhaXuatBanDao().CheckNXB(nxb.TenNXB);
                if (model == false)
                {
                    ModelState.AddModelError("", "Nhà Xuất Bản Này Đã Có ");
                    return View("Add");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var dao = new NhaXuatBanDao();
                        int id = dao.Insert(nxb);
                        if (id > 0)
                        {
                            SetAlert("Thêm Mới Thành Công", "success");
                            return RedirectToAction("Index", "NhaXuatBanAD");
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
            NhaXuatBan nxb = new NhaXuatBanDao().ViewDetails(id);
            return View(nxb);
        }
        [HttpPost]
        public ActionResult Edit(NhaXuatBan nxb)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var model = new NhaXuatBanDao().CheckNXB(nxb.TenNXB);
                if (model == false)
                {
                    ModelState.AddModelError("", "Nhà Xuất Bản Đã Có");
                    return View("Edit");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var dao = new NhaXuatBanDao();
                        var result = dao.Update(nxb);
                        if (result)
                        {
                            SetAlert("Thêm Mới Thành Công", "success");
                            return RedirectToAction("Index", "NhaXuatBanAD");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Cập Nhật Khách Hàng  Thất Bại");
                            return View("Edit");
                        }
                    }
                }
                return View("Index");
            }

        }

        public ActionResult DeleteNXB(int ID)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var a = new NhaXuatBanDao().Delete(ID);

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delele(int ID)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                new NhaXuatBanDao().Delete(ID);
                return RedirectToAction("Index");
            }
        }
    }
}