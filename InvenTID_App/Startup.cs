using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvenTID_App.Startup))]
namespace InvenTID_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
