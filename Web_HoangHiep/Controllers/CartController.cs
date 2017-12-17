using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web_HoangHiep.CommonSession;
using Web_HoangHiep.Dao_Client;
using Web_HoangHiep.Models;

namespace Web_HoangHiep.Controllers
{
    public class CartController : Controller
    {
        #region Giỏ Hàng

        private const string CartSession = "CartSession";

        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[SessionCommand.SessionGioHang];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult DeleteAll()
        {
            Session[SessionCommand.SessionGioHang] = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SuaGioHang(int masach, FormCollection f)
        {
            var model = new SachDao().ViewDetails(masach);
            var cartSession = Session[SessionCommand.SessionGioHang];
            if (cartSession != null)
            {
                var List = (List<CartItem>)cartSession;
                if (List.Exists(n => n.Sach.MaSach == masach))
                {
                    foreach (var item in List)
                    {
                        if (item.Sach.MaSach == masach)
                        {
                            item.SoLuong = int.Parse(f["SoLuong"].ToString());
                        }
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }

                //tra lai ve Session de luu lai nhung thay doi
                Session[SessionCommand.SessionGioHang] = List;
            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SuaGioHang()
        {
            var cart = Session[SessionCommand.SessionGioHang];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult XoaTungSP(int masach)
        {
            //if (lstGioHang != null)
            //{
            //    iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            //}

            var model = new SachDao().CheckSack(masach);
            if (model == false)
            {
                Response.StatusCode = 404;
                return null;
            }

            var sessionCart = (List<CartItem>)Session[SessionCommand.SessionGioHang];
            CartItem cart = sessionCart.SingleOrDefault(n => n.Sach.MaSach == masach);

            if (cart != null)
            {
                sessionCart.RemoveAll(x => x.Sach.MaSach == masach);
                Session[SessionCommand.SessionGioHang] = sessionCart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult XoaGioHang()
        {
            Session[SessionCommand.SessionGioHang] = null;
            return RedirectToAction("Index");
        }

        public ActionResult AddItem(int productId, int quantity, string url)
        {
            var model = new SachDao().ViewDetails(productId);
            var cartSession = Session[SessionCommand.SessionGioHang];

            if (cartSession != null)
            {
                var list = (List<CartItem>)cartSession;
                if (list.Exists(n => n.Sach.MaSach == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Sach.MaSach == productId)
                        {
                            item.SoLuong = item.SoLuong + quantity;
                        }
                    }
                }
                else
                {
                    var Item = new CartItem();
                    Item.Sach = model;
                    Item.SoLuong = quantity;
                    list.Add(Item);
                }

                //Gan vao Session
                Session[SessionCommand.SessionGioHang] = list;
            }
            else
            {
                //Tạo mới đối tượng Item
                var Item = new CartItem();
                Item.Sach = model;
                Item.SoLuong = quantity;
                var list = new List<CartItem>();
                list.Add(Item);
                //Gán vào Sesion
                Session[SessionCommand.SessionGioHang] = list;
            }
            return Redirect(url);
        }

        //[HttpGet]
        //public ActionResult Payment()
        //{
        //    var cart = Session[SessionCommand.SessionGioHang];
        //    var list = new List<CartItem>();
        //    if (cart != null)
        //    {
        //        list = (List<CartItem>)cart;

        //    }
        //    return View(list);
        //}
        //[HttpPost]
        //public ActionResult Payment(string shipName, string mobile, string address, string email)
        //{
        //    var donhang = new DonHang();
        //    donhang.NgayDatHang = DateTime.Now;
        //    donhang.KhachHang.DiaChi = address;
        //    donhang.KhachHang.DienThoai = mobile;
        //    donhang.KhachHang.Email = email;
        //    donhang.KhachHang.TenKhachHang = shipName;
        //    try
        //    {
        //        var id = new DonHangDao().Insert(donhang);
        //        var cart = (List<CartItem>)Session[SessionCommand.SessionGioHang];

        //        var detaildao = new ChiTietDonHangDao();
        //        foreach (var item in cart)
        //        {
        //            var chitietdonhang = new ChiTietDonHang();
        //            chitietdonhang.MaDonHang = id;
        //            chitietdonhang.MaSach = item.Sach.MaSach;
        //            chitietdonhang.SoLuong = item.SoLuong;
        //            chitietdonhang.DonGia = item.Sach.GiaBan;
        //            detaildao.Insert(chitietdonhang);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return RedirectToAction("Success");
        //}

        public ActionResult Success()
        {
            return View();
        }

        #endregion Giỏ Hàng

        #region Đặt Hàng

        public List<CartItem> LayGiohang()
        {
            List<CartItem> listgiohang = Session[SessionCommand.SessionGioHang] as List<CartItem>;
            var list = new List<CartItem>();
            if (list == null)
            {
                listgiohang = new List<CartItem>();
                Session[SessionCommand.SessionGioHang] = listgiohang;
            }
            return listgiohang;
        }

        public ActionResult DatHang()
        {
            if (Session["KhachHang"] == null || Session["KhachHang"].ToString() == "")
            {
                return RedirectToAction("Login", "LoginKH");
            }
            if (Session[SessionCommand.SessionGioHang] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            DonHang ddh = new DonHang();
            KhachHang kh = (KhachHang)Session["KhachHang"];
            List<CartItem> giohang = LayGiohang();
            ddh.MaKH = kh.MaKhacHang;
            ddh.NgayDatHang = DateTime.Now;

            new DonHangDao().Insert(ddh);

            foreach (var item in giohang)
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.MaDonHang = ddh.MaDonHang;
                ctdh.MaSach = item.Sach.MaSach;
                ctdh.SoLuong = item.SoLuong;
                ctdh.DonGia = item.Sach.GiaBan;
                new ChiTietDonHangDao().Insert(ctdh);
            }
            Session[SessionCommand.SessionGioHang] = null;
            return RedirectToAction("Index", "Home");
        }

        #endregion Đặt Hàng
    }
}