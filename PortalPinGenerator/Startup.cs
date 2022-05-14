using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortalPinGenerator.Startup))]
namespace PortalPinGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
