using System.Web.Mvc;
using Web_HoangHiep.Dao_Admin;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class NhaXuatBanADController : Controller
    {
        // GET: Admin/NhaXuatBanAD

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
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
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                NhaXuatBan nxb = new NhaXuatBanDao().ViewDetails(id);
                return View(nxb);
            }
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
        /// <summary>
        /// Xoá nhà xuất bản
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delele(int id)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
             var dao = new NhaXuatBanDao();
              if(dao.DeleteNXB(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
               
            }
        }
    }
}