using System.Web.Mvc;

namespace Web_HoangHiep.Areas.Admin.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return RedirectToAction("Index","SachAD");
        }
    }
}