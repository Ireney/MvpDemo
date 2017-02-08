using Microsoft.Practices.Unity;
using MvpDemo.Data;

namespace MvpDemo.Infrastructure
{
    public class DataDependencyExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            //data
            Container.RegisterType<IQuoteDataContext, YahooQuoteDataContext>();
//            Container.RegisterType<IQuoteDataContext, GoogleQuoteDataContext>();
            Container.RegisterType<IStockQuoteRepository, StockQuoteRepository>();
        }
    }
}