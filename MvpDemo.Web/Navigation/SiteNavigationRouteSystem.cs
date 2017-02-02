using System.Web;
using MvpDemo.Presentation.Navigation;

namespace MvpDemo.Web.Navigation
{
    public class SiteNavigationRouteSystem : INavigationRouteSystem
    {
        public void Goto(string view, object argument)
        {
            switch (view)
            {
                case "home":
                    HttpContext.Current.Response.Redirect("~/default.aspx");
                    break;
                case "about":
                    HttpContext.Current.Response.Redirect($"~/about.aspx?x='{argument}'");
                    break;
            }
        }
    }
}