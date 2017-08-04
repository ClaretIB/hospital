using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalesApp.Startup))]
namespace HospitalesApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
