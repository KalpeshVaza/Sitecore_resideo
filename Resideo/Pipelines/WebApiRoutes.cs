namespace Sitecore.Resideo.Pipelines
{
    using Sitecore.Pipelines;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class WebApiRoutes
    {
        public void Process(PipelineArgs args) 
        {
            RouteTable.Routes.MapHttpRoute("ProductsApi", "api/products/{action}", new
            {
                controller = "Products"
            });
            RouteTable.Routes.MapHttpRoute("LogosApi", "api/logos/{action}", new
            {
                controller = "Logos"
            });
            RouteTable.Routes.MapHttpRoute("LoginApi", "api/login/{action}", new
            {
                controller = "Login"
            });
            RouteTable.Routes.MapRoute("NavigationApi", "api/navigation/{action}", new
            {
                controller = "Navigation"
            });
        }
    }
}