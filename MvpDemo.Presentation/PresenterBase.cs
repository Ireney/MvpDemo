namespace MvpDemo.Presentation
{
    public class PresenterBase<TView> : IPresenter<TView>
    {
        public TView View { get; private set; }

        public virtual void Present(TView view)
        {
            View = view;
        }
    }
}
