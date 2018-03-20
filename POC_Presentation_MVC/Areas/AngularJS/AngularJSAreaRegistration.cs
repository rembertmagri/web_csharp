using System.Web.Mvc;

namespace POC_Presentation_MVC.Areas.AngularJS
{
    public class AngularJSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AngularJS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AngularJS_default",
                "AngularJS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "POC_Presentation_MVC.Areas.AngularJS.Controllers" }
            );
        }
    }
}