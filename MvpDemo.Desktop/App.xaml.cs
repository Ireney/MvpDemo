using System.Windows;
using MvpDemo.Infrastructure;
using MvpDemo.Presentation;
using Ninject;

namespace MvpDemo.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            _container = new StandardKernel();
            _container.Load<CoreDependencyModule>();
            _container.Bind<IDefaultView>().To<MainWindow>();
            _container.Bind<INavigationRouteSystem>().To<DesktopNavigationRouteSystem>().InSingletonScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = _container.Get<MainWindow>();
            Current.MainWindow.Title = "MVP Demo";
        }
    }
}