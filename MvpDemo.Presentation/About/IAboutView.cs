namespace MvpDemo.Presentation.About
{
    public interface IAboutView : IView
    {
        string Message { get; set; }
    }
}