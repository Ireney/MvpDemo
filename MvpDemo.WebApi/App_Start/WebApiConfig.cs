using System.Web.Http;
using Microsoft.Practices.Unity;
using MvpDemo.Infrastructure;
using MvpDemo.WebApi.App_Start;

namespace MvpDemo.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.AddNewExtension<DataDependencyExtension>();
            config.DependencyResolver = new DependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
