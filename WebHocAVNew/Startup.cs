using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebHocAVNew.Startup))]
namespace WebHocAVNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
