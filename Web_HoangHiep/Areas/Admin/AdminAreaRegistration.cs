using System.Web.Mvc;

namespace Web_HoangHiep.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                  "dang-xuat",
                  "Admin/{controller}/{action}/{id}",
                  new { action = "LogOut", id = UrlParameter.Optional },
                  new { controller = "Login" },
                  new[] { "Web_HoangHiep.Areas.Admin.Controllers" }
   );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}