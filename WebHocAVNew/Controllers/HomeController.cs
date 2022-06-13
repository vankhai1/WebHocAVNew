using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHocAVNew.Models;

namespace WebHocAVNew.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult KhoaHoc()
        {
            return View();
        }
        public ActionResult Hoc(int? page)
        {
            if (page == null) page = 1;

            var all_khoahoc = (from kh in data.KhoaHocs select kh).OrderBy(m => m.IdKhoaHoc);
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(all_khoahoc.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Dich()
        {
            return View();
        }
    }
}