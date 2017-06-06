using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Real_Estate_Agency.Startup))]
namespace Real_Estate_Agency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
