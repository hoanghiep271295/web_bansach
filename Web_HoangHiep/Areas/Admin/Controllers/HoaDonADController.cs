using System.Web.Mvc;
using Web_HoangHiep.Dao_Admin;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class HoaDonADController : Controller
    {
        // GET: Admin/HoaDonAD
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new HoaDonDao();
                ViewBag.SearchString = searchString;
                var model = dao.ListAllPaging(searchString, page, pageSize);

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int madonhang)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                DonHang donhang = new HoaDonDao().ViewDetails(madonhang);
                return View(donhang);
            }
        }

        [HttpPost]
        public ActionResult Edit(DonHang donhang)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new HoaDonDao();
                    var result = dao.Update(donhang);
                    if (result)
                    {
                        return RedirectToAction("Index", "HoaDonAD");
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
}