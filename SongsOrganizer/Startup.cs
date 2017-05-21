using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SongsOrganizer.Startup))]
namespace SongsOrganizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
