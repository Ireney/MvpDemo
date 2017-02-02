using System.Linq;
using MvpDemo.Services;

namespace MvpDemo.Presentation
{
    public class StockQuotePresenter : IStockQuotePresenter
    {
        private IDefaultView _view;
        private readonly IQuoteService _quoteService;
        private readonly INavigator _navigator;

        public StockQuotePresenter(IQuoteService quoteService, INavigator navigator)
        {
            _quoteService = quoteService;
            _navigator = navigator;
        }

        public void Present(IDefaultView view)
        {
            _view = view;
        }

        public void Refresh()
        {
            var symbols = _view.Symbols;
            var stocks = _quoteService.GetQuotes(symbols);
            
            _view.Quotes = stocks;

            var providerName = _quoteService.GetProviderName();

            _view.Message = $"{stocks.Count} quotes found. Provided by {providerName}.";
        }

        public void Redirect()
        {
            _navigator.Goto("about", "This text is an argument passed from the presenter.");
        }
    }
}
