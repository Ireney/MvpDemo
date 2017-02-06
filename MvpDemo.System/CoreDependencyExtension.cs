using Microsoft.Practices.Unity;
using MvpDemo.Data;
using MvpDemo.Presentation.About;
using MvpDemo.Presentation.Navigation;
using MvpDemo.Presentation.StockQuote;
using MvpDemo.Services;

namespace MvpDemo.Infrastructure
{
    public class CoreDependencyExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            //data
            Container.RegisterType<IQuoteDataContext, YahooQuoteDataContext>();
//            Container.RegisterType<IQuoteDataContext, GoogleQuoteDataContext>();
            Container.RegisterType<IStockQuoteRepository, StockQuoteRepository>();

            //service
            Container.RegisterType<IQuoteService, QuoteService>();

            //presentation
            Container.RegisterType<INavigator, Navigator>();
            Container.RegisterType<IStockQuotePresenter<IStockQuoteView>, StockQuotePresenter>();
            Container.RegisterType<IAboutPresenter<IAboutView>, AboutPresenter>();
        }
    }
}