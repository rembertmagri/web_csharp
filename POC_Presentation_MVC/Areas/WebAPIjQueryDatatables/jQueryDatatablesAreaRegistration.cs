using System.Web.Mvc;

namespace POC_Presentation_MVC.Areas.jQueryDatatables
{
    public class WebAPIjQueryDatatablesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebAPIjQueryDatatables";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebAPIjQueryDatatables_default",
                "WebAPIjQueryDatatables/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "POC_Presentation_MVC.Areas.WebAPIjQueryDatatables.Controllers" }
            );
        }
    }
}