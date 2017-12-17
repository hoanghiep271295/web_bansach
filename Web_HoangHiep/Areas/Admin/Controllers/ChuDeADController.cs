using System.Web.Mvc;
using Web_HoangHiep.Dao_Admin;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class ChuDeADController : Controller
    {
        // GET: Admin/ChuDeAD

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new ChuDeDao();
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
        public ActionResult Add(ChuDe chude)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var model = new ChuDeDao().CheckChuDe(chude.TenChuDe);
                if (model == false)
                {
                    ModelState.AddModelError("", "Nhà Xuất Bản Này Đã Có ");
                    return View("Add");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var dao = new ChuDeDao();
                        int id = dao.Insert(chude);
                        if (id > 0)
                        {
                            return RedirectToAction("Index", "ChudeAD");
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
                ChuDe chude = new ChuDeDao().ViewDetails(id);
                return View(chude);
            }
        }

        [HttpPost]
        public ActionResult Edit(ChuDe chude)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var model = new ChuDeDao().CheckChuDe(chude.TenChuDe);
                if (model == false)
                {
                    ModelState.AddModelError("", "Nhà Xuất Bản Đã Có");
                    return View("Edit");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var dao = new ChuDeDao();
                        var result = dao.Update(chude);
                        if (result)
                        {
                            return RedirectToAction("Index", "ChuDeAD");
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
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delele(int id)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new ChuDeDao();
                if (dao.DeleteChuDe(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    ModelState.AddModelError("", "Tài Khoản Chưa Tồn Tại !!");
                    return RedirectToAction("Index");
                }

            }
        }
    }
}