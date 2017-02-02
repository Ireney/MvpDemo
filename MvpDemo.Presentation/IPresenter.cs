namespace MvpDemo.Presentation
{
    public interface IPresenter<TView>
    {
        TView View { get; }

        void Present(TView view);
    }
}