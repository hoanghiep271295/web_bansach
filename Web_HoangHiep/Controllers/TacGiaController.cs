using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Web_HoangHiep.Dao_Client;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Controllers
{
    public class TacGiaController : Controller
    {
        // GET: TacGia
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewDetails(int matacgia)
        {

            var model = new TacGiaDao().ViewDetails(matacgia);
            return View(model);
        }
        public ActionResult SachTheoTacGia(int matacgia, int? page)
        {
            int pagesize = 9;
            var pagecurrent = (page ?? 1);
            IQueryable<Sach> model = new TacGiaDao().listSach_TacGia(matacgia);
            return View("SachTheoTacGia", model.ToPagedList(pagecurrent, pagesize));
        }
    }
}