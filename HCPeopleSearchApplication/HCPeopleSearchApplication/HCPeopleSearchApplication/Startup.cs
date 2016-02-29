using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HCPeopleSearchApplication.Startup))]
namespace HCPeopleSearchApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
