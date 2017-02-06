using System.Windows;
using Microsoft.Practices.Unity;
using MvpDemo.Infrastructure;
using MvpDemo.Presentation;
using MvpDemo.Presentation.Navigation;
using MvpDemo.Presentation.StockQuote;

namespace MvpDemo.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            _container = new UnityContainer();
            _container.AddNewExtension<CoreDependencyExtension>();
            _container.RegisterType<INavigationRouteSystem, DesktopNavigationRouteSystem>(new ContainerControlledLifetimeManager());
        }

        private void ComposeObjects()
        {
            Current.MainWindow = _container.Resolve<MainWindow>();
            Current.MainWindow.Title = "MVP Demo";
        }
    }
}