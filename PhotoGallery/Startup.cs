using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoGallery.Startup))]
namespace PhotoGallery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
