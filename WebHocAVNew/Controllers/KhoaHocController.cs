using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHocAVNew.Models;


namespace WebHocAnhVan.Controllers
{
    public class KhoaHocController : Controller
    {
        // GET: KhoaHoc
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult ListKH()
        {   
            var all_khoahoc = from KH in data.KhoaHocs select KH;
            
         
            return View(all_khoahoc);
        }

        public ActionResult CreateKH()
        {

            return View();

        }
        [HttpPost]
        public ActionResult CreateKH(FormCollection collection, KhoaHoc KH)
        {
            var E_IdKH = collection["idkh"];
            var E_TenKH = collection["tenkh"];
            var E_MoTa = collection["mota"];
            var E_Gia = collection["gia"];
            var E_NgayXB = collection["ngayXB"];
            var E_Hinh = collection["hinh"];
            var E_IdGV = collection["IdGV"];


            if (string.IsNullOrEmpty(E_TenKH))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                KH.IdKhoaHoc = int.Parse(E_IdKH);
                KH.TenKhoaHoc = E_TenKH.ToString();
                KH.Mota = E_MoTa.ToString();
                KH.Gia = E_Gia.ToString();
                KH.NgayXuatBan = E_NgayXB.ToString();
                KH.Hinh = E_Hinh.ToString();
                KH.IdGV = int.Parse(E_IdGV);
                data.KhoaHocs.InsertOnSubmit(KH);
                data.SubmitChanges();
                return RedirectToAction("ListKH");
            }
            return this.CreateKH();
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            MyDataDataContext context = new MyDataDataContext();
            KhoaHoc khoaHoc = context.KhoaHocs.SingleOrDefault(p => p.IdKhoaHoc == id);
            if (khoaHoc == null)
            {
                return HttpNotFound();

            }
            return View(khoaHoc);
        }

    }
}