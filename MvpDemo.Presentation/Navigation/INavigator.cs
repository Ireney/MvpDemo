namespace MvpDemo.Presentation.Navigation
{
    public interface INavigator
    {
        void Goto(NavigationTargets view);
        void Goto(NavigationTargets view, object argument);
    }
}