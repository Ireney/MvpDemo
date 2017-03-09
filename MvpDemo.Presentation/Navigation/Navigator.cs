namespace MvpDemo.Presentation.Navigation
{
    public class Navigator : INavigator
    {
        private readonly INavigationRouteStrategy _navigationRouteStrategy;
 
        public Navigator(INavigationRouteStrategy navigationRouteStrategy)
        {
            _navigationRouteStrategy = navigationRouteStrategy;
        }

        public void Goto(NavigationTarget navigationTarget)
        {
            _navigationRouteStrategy?.Goto(navigationTarget, null);
        }

        public void Goto(NavigationTarget navigationTarget, object argument)
        {
            _navigationRouteStrategy?.Goto(navigationTarget, argument);
        }
    }
}