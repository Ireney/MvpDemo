namespace MvpDemo.Presentation
{
    public interface INavigationRouteSystem
    {
        void Goto(string view, object argument);
        void NextViewFrom(string currentView, object argument);
    }
}