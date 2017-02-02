namespace MvpDemo.Presentation
{
    public interface IStockQuotePresenter
    {
        void Present(IDefaultView view);
        void Refresh();
        void Redirect();
    }
}