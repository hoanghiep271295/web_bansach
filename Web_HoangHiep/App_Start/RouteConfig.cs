using System.Web.Mvc;
using System.Web.Routing;

namespace Web_HoangHiep
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "Payment",
             url: "thanh-toan",
             defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
             namespaces: new[] { "Web_HoangHiep.Controllers" }
        );
            routes.MapRoute(
            name: "Tim Kiem",
            url: "tim-kiem",
            defaults: new { controller = "Search", action = "Search", id = UrlParameter.Optional },
            namespaces: new[] { "Web_HoangHiep.Controllers" }
        );
            routes.MapRoute(
             name: "Lien He",
             url: "lien-he",
             defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
             namespaces: new[] { "Web_HoangHiep.Controllers" }
         );
            routes.MapRoute(
    name: "Dang Xuat",
    url: "dang-xuat",
    defaults: new { controller = "LoginKH", action = "DangXuat", id = UrlParameter.Optional },
    namespaces: new[] { "Web_HoangHiep.Controllers" }
    );
            routes.MapRoute(
          name: "Sach Moi",
          url: "sach-moi",
          defaults: new { controller = "Sach", action = "NewProduct", id = UrlParameter.Optional },
          namespaces: new[] { "Web_HoangHiep.Controllers" }
          );

            routes.MapRoute(
           name: "Tat Ca Sach",
           url: "tat-ca-sach",
           defaults: new { controller = "Sach", action = "ListAllProduct", id = UrlParameter.Optional },
           namespaces: new[] { "Web_HoangHiep.Controllers" }
           );

            routes.MapRoute(
            name: "Cap Nhat Gio Hang",
            url: "cap-nhat-gio-hang/{masach}",
            defaults: new { controller = "Cart", action = "SuaGioHang", id = UrlParameter.Optional },
            namespaces: new[] { "Web_HoangHiep.Controllers" }
             );
            routes.MapRoute(
            name: "Product Category",
            url: "chu-de/{machude}",
            defaults: new { controller = "ChuDe", action = "Category", id = UrlParameter.Optional },
            namespaces: new[] { "Web_HoangHiep.Controllers" }
                );

            routes.MapRoute(
              name: "Xoa gio hang",
               url: "xoa-gio-hang",
             defaults: new { controller = "Cart", action = "DeleteAll", id = UrlParameter.Optional },
             namespaces: new[] { "Web_HoangHiep.Controllers" }
             );
            routes.MapRoute(
               name: "Gio Hang",
              url: "gio-hang",
              defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "Web_HoangHiep.Controllers" }
              );
            routes.MapRoute(
        name: "Them Gio Hang",
        url: "them-gio-hang",
        defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
        namespaces: new[] { "Web_HoangHiep.Controllers" }
        );
            routes.MapRoute(
        name: "Xoa Tung San Pham",
        url: "xoa-san-pham/{masach}",
        defaults: new { controller = "Cart", action = "XoaTungSP", id = UrlParameter.Optional },
        namespaces: new[] { "Web_HoangHiep.Controllers" }
         );
            routes.MapRoute(
        name: "Sua Gio Hang",
        url: "sua-gio-hang",
        defaults: new { controller = "Cart", action = "SuaGioHang", id = UrlParameter.Optional },
        namespaces: new[] { "Web_HoangHiep.Controllers" }
             );

            routes.MapRoute(
              name: "Detail Product",
             url: "chi-tiet-san-pham/{id}",
             defaults: new { controller = "Sach", action = "ChiTietSP", id = UrlParameter.Optional },
             namespaces: new[] { "Web_HoangHiep.Controllers" }
               );
            routes.MapRoute(
            name: "SignIn",
             url: "dang-ky",
          defaults: new { controller = "KhachHang", action = "DangKy", id = UrlParameter.Optional },
         namespaces: new[] { "Web_HoangHiep.Controllers" }
       );

            routes.MapRoute(
             name: "Dang Nhap",
              url: "dang-nhap",
           defaults: new { controller = "LoginKH", action = "Login", id = UrlParameter.Optional },
          namespaces: new[] { "Web_HoangHiep.Controllers" }
        );

            routes.MapRoute(
                 name: "Dat Hang",
                  url: "dat-hang",
               defaults: new { controller = "Cart", action = "DatHang", id = UrlParameter.Optional },
              namespaces: new[] { "Web_HoangHiep.Controllers" }
            );

            routes.MapRoute(
                  name: "Payment Success",
                  url: "hoan-thanh",
                  defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                  namespaces: new[] { "OnlineShop.Controllers" }
              );

            routes.MapRoute(
          name: "Nha Xuat Ban",
          url: "{nha-xuat-ban}/{manxb}",
          defaults: new { controller = "NhaXuatBan", action = "SachTheoNXB", id = UrlParameter.Optional }
      );
            routes.MapRoute(
               name: "Tac Gia",
               url: "{tac-gia}/{matacgia}",
               defaults: new { controller = "TacGia", action = "SachTheoTacGia", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "Trang Chu",
            url: "trang-chu",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
        }
    }
}