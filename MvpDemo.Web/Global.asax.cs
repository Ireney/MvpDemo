using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using MvpDemo.Presentation;
using Ninject;
using Ninject.Web.Common;

namespace MvpDemo.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

//            var navigator = new Navigator();
//            var siteNavigationRouteSystem = new SiteNavigationRouteSystem(navigator);
//            navigator.Attach(siteNavigationRouteSystem);
        }
    }
}