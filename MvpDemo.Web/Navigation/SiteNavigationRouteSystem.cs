using System.Web;
using MvpDemo.Presentation.Navigation;

namespace MvpDemo.Web.Navigation
{
    public class SiteNavigationRouteSystem : INavigationRouteSystem
    {
        public void Goto(NavigationTargets view, object argument)
        {
            switch (view)
            {
                case NavigationTargets.Home:
                    HttpContext.Current.Response.Redirect("~/default.aspx");
                    break;
                case NavigationTargets.About:
                    HttpContext.Current.Response.Redirect($"~/about.aspx?x='{argument}'");
                    break;
            }
        }
    }
}