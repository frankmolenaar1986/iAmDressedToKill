using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DressToImpress.Startup))]
namespace DressToImpress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
