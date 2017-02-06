using MvpDemo.Presentation.Navigation;

namespace MvpDemo.Presentation.About
{
    public class AboutPresenter : PresenterBase<IAboutView>, IAboutPresenter<IAboutView>
    {
        private readonly INavigator _navigator;
  
        public AboutPresenter(INavigator navigator)
        {
            _navigator = navigator;
        }

        public void HandleParameter(object parameter)
        {
           View.Message = parameter == null ? "[No value passed]" : parameter as string;
        }

        public void Redirect()
        {
            _navigator.Goto(NavigationTargets.Home);
        }
    }
}
