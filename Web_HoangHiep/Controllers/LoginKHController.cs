using System.Web.Mvc;
using Web_HoangHiep.CommonSession;
using Web_HoangHiep.Dao_Client;
using Web_HoangHiep.Models;
using Web_HoangHiep.Models.LoginModelClient;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using System.Net;

namespace Web_HoangHiep.Controllers
{
    public class LoginKHController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["KhachHang"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        [HttpPost]
        public ActionResult Login(LoginModelClient model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoginDaoClient();
                var result = dao.Check(model.taikhoan, model.password);

                if (result == false)
                {
                    ModelState.AddModelError("", "Đăng Nhập Thất Bại");
                    return View("Login");
                }
                else
                if (result == true)
                {
                    var khachhang = new KhachhangDao().GetKhachhang(model.taikhoan, model.password);
                    Session["KhachHang"] = khachhang;
                    Session["UserName"] = khachhang.TenKhachHang;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
                ModelState.AddModelError("", "Vui Lòng Đăng Nhập Đủ");

            return View("Index");
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy(KhachHang kh)
        {
            return View();
        }

        public ActionResult DangXuat()
        {
            Session["KhachHang"] = null;
            Session[SessionCommand.SessionGioHang] = null;
            return RedirectToAction("Login","LoginKH");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void LoginWithGooglePlus()
        {
            GoogleConnect.ClientId = "478955962912-3onll49e9glhaa349fttcrl78g1jqhfu.apps.googleusercontent.com";
            GoogleConnect.ClientSecret = "rmBL8avao9OtSaLsILzcdAtM";
            GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];
            GoogleConnect.Authorize("profile", "email");
        }
        [ActionName("LoginWithGooglePlus")]
        public ActionResult LoginWithGooglePlusConfirmed()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string code = Request.QueryString["code"];
                string json = GoogleConnect.Fetch("me", code);
                GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);

                var dao = new KhachhangDao();
                KhachHang kh=dao.LoginGoogle(profile.Id, profile.DisplayName, profile.Emails[0].Value);
                Session["KhachHang"] = kh;
                Session["UserName"] = kh.TenKhachHang;
                return RedirectToAction("Index", "Home");
            }
            if (Request.QueryString["error"] == "access_denied")
            {
                return Content("access_denied");
            }
            return RedirectToAction("Index", "Home");

        }
    }
}