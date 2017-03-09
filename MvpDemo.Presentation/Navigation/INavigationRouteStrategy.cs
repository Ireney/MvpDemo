namespace MvpDemo.Presentation.Navigation
{
    public interface INavigationRouteStrategy
    {
        void Goto(NavigationTarget navigationTarget, object argument);
    }
}