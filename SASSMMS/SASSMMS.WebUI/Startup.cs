using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SASSMMS.WebUI.Startup))]
namespace SASSMMS.WebUI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
