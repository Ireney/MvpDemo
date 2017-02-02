namespace MvpDemo.Presentation.Navigation
{
    public interface INavigationRouteSystem
    {
        void Goto(string view, object argument);
    }
}