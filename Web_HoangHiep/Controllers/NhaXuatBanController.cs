using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web_HoangHiep.Dao_Client;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SachTheoNXB(int manxb, int? page)
        {
            int pagesize = 9;
            var pagecurent = (page ?? 1);
            IEnumerable<Sach> model = new NhaXuatBanDao().SachTheoNXB(manxb);
            return View("SachTheoNXB", model.ToPagedList(pagecurent, pagesize));
        }
    }
}