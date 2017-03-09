using System.Web;
using MvpDemo.Presentation.Navigation;

namespace MvpDemo.Web.Navigation
{
    public class SiteNavigationRouteStrategy : INavigationRouteStrategy
    {
        public void Goto(NavigationTarget navigationTarget, object argument)
        {
            switch (navigationTarget)
            {
                case NavigationTarget.Home:
                    HttpContext.Current.Response.Redirect("~/default.aspx");
                    break;
                case NavigationTarget.About:
                    HttpContext.Current.Response.Redirect($"~/about.aspx?x='{argument}'");
                    break;
            }
        }
    }
}