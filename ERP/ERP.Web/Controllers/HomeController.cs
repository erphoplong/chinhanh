using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Web.Models;
using ERP.Web.Models.Database;

namespace ERP.Web.Controllers
{
    public class HomeController : Controller
    {
        HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return RedirectToAction("Index", "HangHoaDaiLy");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String username, String password)
        {
            var user = db.HT_NGUOI_DUNG.SingleOrDefault(x => x.USERNAME == username && x.PASSWORD == password && x.ALLOWED == true);
            if (user != null)
            {


                
                Session["USERNAME"] = user.USERNAME;
                Session["HO_VA_TEN"] = user.HO_VA_TEN;
                Session["IS_AMIN"] = user.IS_ADMIN;
                Session["AVATAR"] = user.AVATAR;
                Session["MA_CONG_TY"] = user.MA_CONG_TY;
                Session["LOAI_USER"] = user.CCTC_CONG_TY.CAP_TO_CHUC;
                if(Session["MA_CONG_TY"].ToString() == "HOP_LONG")
                {
                    //return RedirectToAction("HopLong/HopLongHome/Index");
                    return RedirectToAction("Index", "HopLongHome", new { area = "HopLong" });
                }
                if (Session["MA_CONG_TY"].ToString() == "TAHCM")
                {
                    //return RedirectToAction("HopLong/HopLongHome/Index");
                    return RedirectToAction("Index", "TAHCMHome", new { area = "TruongAnHCM" });
                }
                if (Session["MA_CONG_TY"].ToString() == "TAHAN")
                {
                    //return RedirectToAction("HopLong/HopLongHome/Index");
                    return RedirectToAction("Index", "TAHANHome", new { area = "TruongAnHaNoi" });
                }
                if (Session["MA_CONG_TY"].ToString() == "TADAN")
                {
                    //return RedirectToAction("HopLong/HopLongHome/Index");
                    return RedirectToAction("Index", "TADANHome", new { area = "TruongAnDaNang" });
                }
                else
                {
                    return RedirectToAction("Index");
                }
                


            }
            ViewBag.error = "Wrong username or password";
            return View();
        }

        public ActionResult Logout()
        {
            
            Session["USERNAME"] = null;
            Session["HO_VA_TEN"] = null;
            Session["IS_AMIN"] = null;
            Session["AVATAR"] = null;
            Session["MA_CONG_TY"] = null;
            Session["LOAI_USER"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult NotificationAuthorize()
        {
            return View();
        }
    }
}
