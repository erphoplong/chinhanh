using ERP.Web.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.TruongAnHCM.Controllers
{
    [AuthorizeBussiness]
    public class HangspTAHCMController : Controller
    {
        // GET: TruongAnHCM/HangspTAHCM
        public ActionResult Index()
        {
            return View();
        }
    }
}