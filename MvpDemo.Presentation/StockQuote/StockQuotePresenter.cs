using MvpDemo.Presentation.Navigation;
using MvpDemo.Services;

namespace MvpDemo.Presentation.StockQuote
{
    public class StockQuotePresenter : PresenterBase<IStockQuoteView>, IStockQuotePresenter<IStockQuoteView>
    {
        private readonly IQuoteService _quoteService;
        private readonly INavigator _navigator;

        public StockQuotePresenter(IQuoteService quoteService, INavigator navigator)
        {
            _quoteService = quoteService;
            _navigator = navigator;
        }

        public void Refresh()
        {
            var symbols = View.Symbols;
            var stocks = _quoteService.GetQuotes(symbols);

            View.Quotes = stocks;

            var providerName = _quoteService.GetProviderName();

            View.Message = $"{stocks.Count} quotes found. Provided by {providerName}.";
        }

        public void Redirect()
        {
            _navigator.Goto("about", "This text is an argument passed from the presenter.");
        }
    }
}