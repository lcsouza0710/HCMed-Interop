using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HCMed_Interop.Startup))]
namespace HCMed_Interop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}