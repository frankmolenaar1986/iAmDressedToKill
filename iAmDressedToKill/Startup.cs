using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iAmDressedToKill.Startup))]
namespace iAmDressedToKill
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
