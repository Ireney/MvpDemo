using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Practices.Unity;
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
            //service
            Container.RegisterType<IQuoteService, QuoteService>();
//            Container.RegisterType<IQuoteService, RemoteQuoteService>();
            Container.RegisterType<HttpClient>(new InjectionFactory(factory =>
            {
                var client = new HttpClient {BaseAddress = new Uri("http://localhost:62228/")};
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            }));

            //presentation
            Container.RegisterType<INavigator, Navigator>();
            Container.RegisterType<IStockQuotePresenter<IStockQuoteView>, StockQuotePresenter>();
            Container.RegisterType<IAboutPresenter<IAboutView>, AboutPresenter>();
        }
    }
}