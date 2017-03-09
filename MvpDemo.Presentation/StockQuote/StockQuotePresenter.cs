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
            var quotes = _quoteService.GetQuotes(symbols);
            var providerName = _quoteService.GetProviderName();

            View.Quotes = quotes;
            View.Summary = $"{quotes.Count} quotes found. Provided by {providerName}.";
        }

        public void Redirect()
        {
            _navigator.Goto(NavigationTarget.About, "This text is an argument passed from the presenter.");
        }
    }
}