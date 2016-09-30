using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnquetesAFPA.Startup))]
namespace EnquetesAFPA
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
