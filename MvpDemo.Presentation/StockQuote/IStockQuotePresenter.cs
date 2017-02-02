namespace MvpDemo.Presentation.StockQuote
{
    public interface IStockQuotePresenter<TView> : IPresenter<TView>
    {
        void Refresh();
        void Redirect();
    }
}