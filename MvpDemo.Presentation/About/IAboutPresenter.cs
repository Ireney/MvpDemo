namespace MvpDemo.Presentation.About
{
    public interface IAboutPresenter<TView> : IPresenter<TView>
    {
        void HandleParameter(object parameter);
        void Redirect();
    }
}