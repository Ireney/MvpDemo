using System.Windows;
using MvpDemo.Presentation.About;

namespace MvpDemo.Desktop
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : IAboutView
    {
        private readonly IAboutPresenter<IAboutView> _presenter;

        public About(IAboutPresenter<IAboutView> presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.Bind(this);

            Loaded += (sender, args) => _presenter.HandleParameter(Argument);
        }

        public string Message
        {
            get { return LabelParameter.Content as string; }
            set { LabelParameter.Content = value; }
        }

        public object Argument { get; set; }

        private void ButtonHomeClick(object sender, RoutedEventArgs e)
        {
            _presenter.Redirect();
        }
    }
}