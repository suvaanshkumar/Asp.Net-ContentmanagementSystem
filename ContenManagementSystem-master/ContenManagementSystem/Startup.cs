using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContenManagementSystem.Startup))]
namespace ContenManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
