namespace MvpDemo.Presentation.Navigation
{
    public interface INavigator
    {
        void Attach(INavigationRouteSystem navigationRouteSystem);
        void Goto(string view);
        void Goto(string view, object argument);
        void NextViewFrom(string currentView);
        void NextViewFrom(string currentView, object argument);
    }
}