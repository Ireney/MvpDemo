using System.Collections.Generic;
using System.Windows;
using MvpDemo.Domain;
using MvpDemo.Presentation;
using MvpDemo.Presentation.Navigation;
using MvpDemo.Presentation.StockQuote;

namespace MvpDemo.Desktop
{
    public partial class MainWindow : IStockQuoteView
    {
        private readonly IStockQuotePresenter _presenter;

        public MainWindow(IStockQuotePresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.Present(this);
        }

        public string Message
        {
            get { return LabelMessage.Content as string; }
            set { LabelMessage.Content = value; }
        }

        public string Symbols
        {
            get { return TextBoxInput.Text; }
            set { TextBoxInput.Text = value; }
        }

        IList<StockInfo> IStockQuoteView.Quotes
        {
            get { return DataGridQuotes.ItemsSource as IList<StockInfo>; }
            set { DataGridQuotes.ItemsSource = value; }
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            _presenter.Refresh();
        }

        private void ButtonRedirect_Click(object sender, RoutedEventArgs e)
        {
            _presenter.Redirect();
        }
    }
}