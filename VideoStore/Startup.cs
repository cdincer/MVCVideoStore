using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoStore.Startup))]
namespace VideoStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
