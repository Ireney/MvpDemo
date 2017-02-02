using System;

namespace MvpDemo.Presentation
{
    public class Navigator : INavigator
    {
        private  INavigationRouteSystem _navigationRouteSystem;
 
        public Navigator(INavigationRouteSystem navigationRouteSystem)
        {
            _navigationRouteSystem = navigationRouteSystem;
        }

        public void Attach(INavigationRouteSystem navigationRouteSystem)
        {
            _navigationRouteSystem = navigationRouteSystem;
        }

        public void Goto(string view)
        {
            _navigationRouteSystem?.Goto(view, null);
        }

        public void Goto(string view, object argument)
        {
            _navigationRouteSystem?.Goto(view, argument);
        }

        public void NextViewFrom(string currentView)
        {
            _navigationRouteSystem?.NextViewFrom(currentView, null);
        }

        public void NextViewFrom(string currentView, object argument)
        {
            _navigationRouteSystem?.NextViewFrom(currentView, argument);
        }
    }
}