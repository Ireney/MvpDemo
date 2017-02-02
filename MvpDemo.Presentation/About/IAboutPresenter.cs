namespace MvpDemo.Presentation.About
{
    public interface IAboutPresenter
    {
        void Present(IAboutView view);
        void HandleParameter(object parameter);
        void Redirect();
    }
}