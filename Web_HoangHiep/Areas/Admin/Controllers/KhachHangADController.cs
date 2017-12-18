using System.Net;
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

        [HttpGet]
        public ActionResult DeleteKH(int ID)
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

        public ActionResult Email(int id)
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

        [HttpPost]
        public ActionResult SendEmail(string email, string subject, string content)
        {
            var fromAddress = "vuhoanghiep271295@gmail.com";
            var toAddress = email;
            const string fromPassword = "ngochien21031997";
            string body = content;
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            smtp.Send(fromAddress, toAddress, subject, body);
            return RedirectToAction("Index","KhachHangAD");
        }
    }
}