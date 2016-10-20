using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoGallery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AlbumDetails",
                url: "Albums/Details/{albumName}",
                defaults: new { controller = "Albums", action = "Details", albumName  = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Albums", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
