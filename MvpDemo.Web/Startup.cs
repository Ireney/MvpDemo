using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvpDemo.Web.Startup))]
namespace MvpDemo.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
