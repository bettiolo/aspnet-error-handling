using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace AspNetErrorHandling.WebForms
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();
        }
    }
}
