using System.Web.Mvc;
using Web_HoangHiep.Dao_Admin;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class KhachHangADController : Controller
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new KhachHangDao();
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
        public ActionResult Add(KhachHang kh)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var result = new KhachHangDao().CheckKhachHang(kh.TaiKhoan, kh.MatKhau);
                if (result == false)
                {
                    ModelState.AddModelError("", "Tài Khoản này đã tồn tại");
                    return View("Add");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var dao = new KhachHangDao();
                        int id = dao.Insert(kh);
                        if (id > 0)
                        {
                            return RedirectToAction("Index", "KhachHangAD");
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
            var khachhang = new KhachHangDao().ViewDetails(id);
            return View(khachhang);
        }

        [HttpPost]
        public ActionResult Edit(KhachHang kh)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new KhachHangDao();
                    var result = dao.Update(kh);
                    if (result)
                    {
                        return RedirectToAction("Index", "KhachHangAD");
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

        [HttpDelete]
        public ActionResult Delele(int ID)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                new KhachHangDao().Delete(ID);
                return RedirectToAction("Index");
            }
        }

        public ActionResult SendEmail(int id)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new KhachHangDao();
                var model = dao.getById(id);
                if (model != null)
                {
                    ViewBag.Email = model.Email;
                    return View();
                }
                else
                    return RedirectToAction("Index", "KhachHangAD");
            }
        }
    }
}