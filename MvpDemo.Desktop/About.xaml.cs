using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MvpDemo.Presentation;
using Ninject;

namespace MvpDemo.Desktop
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : IAboutView
    {
        private readonly IAboutPresenter _presenter;

        public About(IAboutPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.Present(this);

            Loaded += (sender, args) => _presenter.HandleParameter(Argument);
        }

        public string Message
        {
            get { return LabelParameter.Content as string; }
            set { LabelParameter.Content = value; }
        }

        public object Argument { get; set; }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _presenter.Redirect();
        }
    }
}