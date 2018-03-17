using System.Web.Mvc;

namespace POC_Presentation_MVC.Areas.PureMVC
{
    public class PureMVCAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PureMVC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PureMVC_default",
                "PureMVC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "POC_Presentation_MVC.Areas.PureMVC.Controllers" }
            );
        }
    }
}