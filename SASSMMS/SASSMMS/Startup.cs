using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SASSMMS.Startup))]
namespace SASSMMS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
