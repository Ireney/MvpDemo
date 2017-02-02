using System.Web;
using MvpDemo.Presentation;

namespace MvpDemo.Web
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

        public void NextViewFrom(string currentView, object argument)
        {
            switch (currentView)
            {
                case "home":
                    // Calculate next view using logic
                    break;
            }
        }

    }
}