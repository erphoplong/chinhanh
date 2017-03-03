using ERP.Web.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.TruongAnHCM.Controllers
{
    public class PhongBanTAHCMController : Controller
    {
        [AuthorizeBussiness]
        // GET: TruongAnHCM/PhongBanTAHCM
        public ActionResult Index()
        {
            return View();
        }
    }
}