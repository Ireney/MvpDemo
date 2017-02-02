using MvpDemo.Data;
using MvpDemo.Presentation;
using MvpDemo.Services;
using Ninject.Modules;

namespace MvpDemo.Infrastructure
{
    public class CoreDependencyModule : NinjectModule
    {
        public override void Load()
        {
            //data
//            Bind<IQuoteDataContext>().To<YahooQuoteDataContext>().InRequestScope();
            Bind<IQuoteDataContext>().To<GoogleQuoteDataContext>().InSingletonScope();
            Bind<IStockQuoteRepository>().To<StockQuoteRepository>().InTransientScope();

            //services
            Bind<IQuoteService>().To<QuoteService>().InTransientScope();

            //presentation
            Bind<INavigator>().To<Navigator>().InSingletonScope();
            Bind<IStockQuotePresenter>().To<StockQuotePresenter>().InTransientScope();
            Bind<IAboutPresenter>().To<AboutPresenter>().InTransientScope();
        }
    }
}