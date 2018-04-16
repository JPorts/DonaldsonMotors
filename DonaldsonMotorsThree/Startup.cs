using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DonaldsonMotorsThree.Startup))]
namespace DonaldsonMotorsThree
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
