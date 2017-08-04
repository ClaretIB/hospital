using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hospitales.Startup))]
namespace Hospitales
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
