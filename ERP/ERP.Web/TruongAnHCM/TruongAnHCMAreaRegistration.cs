using System.Web.Mvc;

namespace ERP.Web.Areas.TruongAnHCM
{
    public class TruongAnHCMAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TruongAnHCM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TruongAnHCM_default",
                "TruongAnHCM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}