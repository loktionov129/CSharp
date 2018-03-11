using System.Web.Mvc;
using System.Web.Routing;

namespace testAsp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Shop",
                url: "shop/{category}",
                defaults: new { controller = "Catalog", action = "Filter", category = UrlParameter.Optional },
                namespaces: new[] { "testAsp.Controllers" },
                constraints: new { controller = "^[Cc]atalog$" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
