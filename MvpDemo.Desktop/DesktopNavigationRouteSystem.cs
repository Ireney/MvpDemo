using System.Windows;
using Microsoft.Practices.Unity;
using MvpDemo.Presentation.Navigation;

namespace MvpDemo.Desktop
{
    public class DesktopNavigationRouteSystem : INavigationRouteSystem
    {
        private About _aboutWindow;
        private readonly IUnityContainer _container;

        public DesktopNavigationRouteSystem(IUnityContainer container)
        {
            _container = container;
        }

        public void Goto(string view, object argument)
        {
            switch (view)
            {
                case "home":
                    if (_aboutWindow != null)
                    {
                        _aboutWindow.Close();
                        _aboutWindow = null;
                    }
                    break;
                case "about":
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