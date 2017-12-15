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
    public class ChiTietDonHangADController : BaseController
    {
        // GET: Admin/ChiTietDonHangAD
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new ChiTietDonHangDao();
                ViewBag.SearchString = searchString;
                var model = dao.ListAllPaging(searchString, page, pageSize);
                return View(model);
            }
        }
    }
}