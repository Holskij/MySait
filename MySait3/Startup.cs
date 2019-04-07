using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySait3.Startup))]
namespace MySait3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
