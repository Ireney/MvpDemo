namespace MvpDemo.Presentation.Navigation
{
    public interface INavigator
    {
        void Goto(NavigationTarget navigationTarget);
        void Goto(NavigationTarget navigationTarget, object argument);
    }
}