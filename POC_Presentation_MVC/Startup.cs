using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POC_Presentation_MVC.Startup))]
namespace POC_Presentation_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
