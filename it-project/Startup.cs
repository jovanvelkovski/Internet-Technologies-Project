using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(it_project.Startup))]
namespace it_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
