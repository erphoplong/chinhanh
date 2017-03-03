using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.TruongAnHCM.Controllers
{
    public class TAHCMHomeController : Controller
    {
        // GET: TruongAnHCM/TAHCMHome
        public ActionResult Index()
        {
            return RedirectToAction("Index","HangHoaTAHCM");
        }
    }
}