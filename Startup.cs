using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(seminarium.Startup))]
namespace seminarium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
