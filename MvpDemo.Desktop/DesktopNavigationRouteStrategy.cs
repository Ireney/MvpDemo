using System.Windows;
using Microsoft.Practices.Unity;
using MvpDemo.Presentation.Navigation;

namespace MvpDemo.Desktop
{
    public class DesktopNavigationRouteStrategy : INavigationRouteStrategy
    {
        private About _aboutWindow;
        private readonly IUnityContainer _container;

        public DesktopNavigationRouteStrategy(IUnityContainer container)
        {
            _container = container;
        }

        public void Goto(NavigationTarget navigationTarget, object argument)
        {
            switch (navigationTarget)
            {
                case NavigationTarget.Home:
                    if (_aboutWindow != null)
                    {
                        _aboutWindow.Close();
                        _aboutWindow = null;
                    }
                    break;
                case NavigationTarget.About:
                    if (_aboutWindow == null)
                    {
                        _aboutWindow = _container.Resolve<About>();
                        _aboutWindow.Owner = Application.Current.MainWindow;
                        _aboutWindow.Argument = argument;
                    }
                    _aboutWindow.ShowDialog();
                    break;
            }
        }
    }
}