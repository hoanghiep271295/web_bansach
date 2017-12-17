using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;
using Web_HoangHiep.Dao_Client;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpPost]
        public ActionResult Search(FormCollection f, int? page)
        {
            string tukhoa = f["txtSearching"].ToString();

            ViewBag.TuKhoa = tukhoa;
            List<Sach> model = new SearchDao().TimKiem(tukhoa);
            var pagecurrent = (page ?? 1);
            var pagesize = 9;
            if (model.Count == 0)
            {
                ViewBag.ThongBao = "Không Tìm Thấy Kết Quả Nào Trùng Khớp Với " + tukhoa;
            }

            return View(model.ToPagedList(pagecurrent, pagesize));
        }

        [HttpGet]
        public ActionResult Search(int? page, string tukhoa)
        {
            ViewBag.TuKhoa = tukhoa;
            List<Sach> model = new SearchDao().TimKiem(tukhoa);
            var pagecurrent = (page ?? 1);
            var pagesize = 9;
            if (model.Count == 0)
            {
                ViewBag.ThongBao = "Không Tìm Thấy Kết Quả Nào Trùng Khớp Với " + tukhoa;
            }
            return View(model.ToPagedList(pagecurrent, pagesize));
        }
    }
}