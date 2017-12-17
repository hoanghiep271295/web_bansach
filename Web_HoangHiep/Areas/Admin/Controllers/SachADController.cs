using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_HoangHiep.Dao_Admin;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class SachADController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: Admin/SachAD
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new SachDao();
                ViewBag.SearchString = searchString;
                var model = dao.ListAllPaging(searchString, page, pageSize);

                return View(model);
            }
        }

        public void SetViewBag(int? select = null)
        {
            var dao = new ChuDeDao();
            ViewBag.ChuDe = new SelectList(dao.listAllChuDe(), "MaChuDe", "TenChuDe", select);
        }

        public void SetViewBag2(int? select = null)
        {
            var dao = new NhaXuatBanDao();
            ViewBag.NhaXuatBan = new SelectList(dao.listAllNXB(), "MaNXB", "TenNXB", select);
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
                ViewBag.MaChuDe = new SelectList(db.ChuDes, "MaChuDe", "TenChuDe");
                ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Add(Sach sach, HttpPostedFileBase fileUpload)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.MaChuDe = new SelectList(db.ChuDes.OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
                ViewBag.MaNXB = new SelectList(db.NhaXuatBans.OrderBy(n => n.MaNXB), "MaNXB", "TenNXB");

                var model = new SachDao().CheckSach(sach.TenSach);
                if (model == false)
                {
                    ViewBag.ThongBao = "Sách Đã Tồn Tại Trong Danh Sách Sách";
                    return View("Add");
                }
                else
                {
                    if (fileUpload == null)
                    {
                        ViewBag.ThongBao = "Nhập Hình Ảnh";
                        return View();
                    }

                    if (ModelState.IsValid)
                    {
                        var fileName = Path.GetFileName(fileUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/HinhAnhSP/"), fileName);
                        if (System.IO.File.Exists(path))
                        {
                            ViewBag.ThongBao = "Hình Ảnh Đã Tồn Tại";
                            return View("Add");
                        }
                        else
                        {
                            fileUpload.SaveAs(path);
                        }
                        sach.AnhBia = fileUpload.FileName;
                        db.Saches.Add(sach);
                        db.SaveChanges();
                        return RedirectToAction("Index", "SachAD");
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
                var dao = new ChuDeDao();
                var sach = db.Saches.Find(id);
                ViewBag.MaChuDe = new SelectList(db.ChuDes.OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe", sach.MaChuDe);
                ViewBag.MaNXB = new SelectList(db.NhaXuatBans.OrderBy(n => n.MaNXB), "MaNXB", "TenNXB", sach.MaNXB);
                return View(sach);
            }
        }

        [HttpPost]
        public ActionResult Edit(Sach sach)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.MaChuDe = new SelectList(db.ChuDes.OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe", sach.MaChuDe);
                ViewBag.MaNXB = new SelectList(db.NhaXuatBans.OrderBy(n => n.MaNXB), "MaNXB", "TenNXB", sach.MaNXB);
                var model = new SachDao().CheckSach(sach.TenSach);

                if (ModelState.IsValid)
                {
                    var dao = new SachDao();

                    var result = dao.Update(sach);
                    if (result)
                    {
                        return RedirectToAction("Index", "SachAD");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập Nhật Sach Thất Bại");
                        return View("Edit");
                    }

                    //}
                }
                return View("Index");
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
                new SachDao().Delete(ID);

                return RedirectToAction("Index");
            }
        }
    }
}