using System.Windows;
using MvpDemo.Presentation.Navigation;
using Ninject;

namespace MvpDemo.Desktop
{
    public class DesktopNavigationRouteSystem : INavigationRouteSystem
    {
        private readonly IKernel _kernel;
        private About _aboutWindow;

        public DesktopNavigationRouteSystem(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Goto(NavigationTargets view, object argument)
        {
            switch (view)
            {
                case NavigationTargets.Home:
                    if (_aboutWindow != null)
                    {
                        _aboutWindow.Close();
                        _aboutWindow = null;
                    }
                    break;
                case NavigationTargets.About:
                    if (_aboutWindow == null)
                    {
                        _aboutWindow = _kernel.Get<About>();
                        _aboutWindow.Owner = Application.Current.MainWindow;
                        _aboutWindow.Argument = argument;
                    }
                    _aboutWindow.ShowDialog();
                    break;
            }
        }
    }
}