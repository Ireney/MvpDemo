namespace MvpDemo.Presentation.Navigation
{
    public interface INavigationRouteSystem
    {
        void Goto(NavigationTargets view, object argument);
    }
}