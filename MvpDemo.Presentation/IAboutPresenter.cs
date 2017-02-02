namespace MvpDemo.Presentation
{
    public interface IAboutPresenter
    {
        void Present(IAboutView view);
        void HandleParameter(object parameter);
        void Redirect();
    }
}