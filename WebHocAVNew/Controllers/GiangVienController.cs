using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHocAVNew.Models;

namespace WebHocAVNew.Controllers
{
    [Authorize]
    public class GiangVienController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: GiangVien
        public ActionResult ListGV()
        {
            var all_giangvien = from GV in data.Giangviens select GV;
            return View(all_giangvien);
        }
        public ActionResult CreateGV(FormCollection collection, Giangvien giangvien)
        {
            
            var E_TenGV = collection["tengv"];
            var E_SDT = collection["SDT"];
            var E_DCGV = collection["dcgv"];
            var E_NgaySinhGV = collection["ngaysinhGV"];
            var E_id = collection["id"];
           


            if (string.IsNullOrEmpty(E_TenGV))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                giangvien.HoTenGV = E_TenGV.ToString();
                giangvien.SDT = E_SDT.ToString();
                giangvien.DCGV=E_DCGV.ToString();
                giangvien.NgaySinhGV=E_NgaySinhGV.ToString();
                giangvien.Id = E_id.ToString();
                
                data.Giangviens.InsertOnSubmit(giangvien);
                data.SubmitChanges();
                return RedirectToAction("ListGV");
            }
            return View();
        }
     
    }
}