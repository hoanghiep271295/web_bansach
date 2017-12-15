using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_HoangHiep.Dao_Client;
using Web_HoangHiep.Models;
using PagedList;
using PagedList.Mvc;

namespace Web_HoangHiep.Controllers
{
    public class ChuDeController : Controller
    {

        // GET: ChuDe

        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Category(int? page,int machude)
        {
            int pagesize = 9;
            var pagecurrent = (page ?? 1);

            var dao = new ChuDeDao();
        

            IQueryable<Sach> model = dao.ListAllPaging(machude);
            

            return View("Category",model.ToPagedList(pagecurrent,pagesize));
        }
    }
}