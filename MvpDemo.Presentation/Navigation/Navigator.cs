namespace MvpDemo.Presentation.Navigation
{
    public class Navigator : INavigator
    {
        private readonly INavigationRouteSystem _navigationRouteSystem;
 
        public Navigator(INavigationRouteSystem navigationRouteSystem)
        {
            _navigationRouteSystem = navigationRouteSystem;
        }

        public void Goto(NavigationTargets view)
        {
            _navigationRouteSystem?.Goto(view, null);
        }

        public void Goto(NavigationTargets view, object argument)
        {
            _navigationRouteSystem?.Goto(view, argument);
        }
    }
}