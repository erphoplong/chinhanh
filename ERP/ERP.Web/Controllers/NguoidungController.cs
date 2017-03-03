using ERP.Web.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.TruongAnHCM.Controllers
{
    public class NguoidungController : Controller
    {
        [AuthorizeBussiness]
        // GET: TruongAnHCM/Nguoidung
        public ActionResult Index()
        {
            return View();
        }
    }
}