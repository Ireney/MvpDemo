namespace MvpDemo.Presentation.StockQuote
{
    public interface IStockQuotePresenter
    {
        void Present(IStockQuoteView view);
        void Refresh();
        void Redirect();
    }
}