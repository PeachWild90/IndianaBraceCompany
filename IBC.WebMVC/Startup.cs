using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IBC.WebMVC.Startup))]
namespace IBC.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
