using System.Web.Mvc;
using Web_HoangHiep.Dao_Admin;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class ChiTietDonHangADController : Controller
    {
        // GET: Admin/ChiTietDonHangAD
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var dao = new ChiTietDonHangDao();
                ViewBag.SearchString = searchString;
                var model = dao.ListAllPaging(searchString, page, pageSize);
                return View(model);
            }
        }
    }
}