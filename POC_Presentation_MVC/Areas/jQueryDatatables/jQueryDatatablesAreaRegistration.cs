using System.Web.Mvc;

namespace POC_Presentation_MVC.Areas.jQueryDatatables
{
    public class jQueryDatatablesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "jQueryDatatables";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "jQueryDatatables_default",
                "jQueryDatatables/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "POC_Presentation_MVC.Areas.jQueryDatatables.Controllers" }
            );
        }
    }
}