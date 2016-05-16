using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dev3.Startup))]
namespace Dev3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
