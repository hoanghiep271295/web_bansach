using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;
using Web_HoangHiep.Dao_Client;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewProduct(int? page)
        {
            int pagecurent = (page ?? 1);
            int pageSize = 9;
            var dao = new SachDao();
            List<Sach> model = dao.ListSachMoi();
            return View(model.ToPagedList(pagecurent, pageSize));
        }

        public ActionResult ListAllProduct(int page = 1, int pagesize = 9)
        {
            var model = new SachDao().ListAllSach(page, pagesize);
            return View(model);
        }

        public ActionResult ChiTietSP(int id)
        {
            ViewBag.RelateProduct = new SachDao().ListRelate(id);
            var model = new SachDao().Details(id);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult SieuPhamSach()
        {
            var model = new SachDao().SieuPham();
            return PartialView(model);
        }

        public ActionResult ProductCatelogy()
        {
            return View();
        }
    }
}