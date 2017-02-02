namespace MvpDemo.Presentation.About
{
    public interface IAboutPresenter<TView> : IPresenter<TView>
    {
        void Present(IAboutView view);
        void HandleParameter(object parameter);
        void Redirect();
    }
}