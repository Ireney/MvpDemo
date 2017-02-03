namespace MvpDemo.Presentation
{
    public interface IPresenter<TView>
    {
        TView View { get; }

        void Bind(TView view);
    }
}