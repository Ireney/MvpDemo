using System.Collections.Generic;
using System.Windows;
using MvpDemo.Domain;
using MvpDemo.Presentation.StockQuote;

namespace MvpDemo.Desktop
{
    public partial class MainWindow : IStockQuoteView
    {
        private readonly IStockQuotePresenter<IStockQuoteView> _presenter;

        public MainWindow(IStockQuotePresenter<IStockQuoteView> presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.Bind(this);
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

        private void ButtonRedirectClick(object sender, RoutedEventArgs e)
        {
            _presenter.Redirect();
        }

        private void ButtonRefreshClick(object sender, RoutedEventArgs e)
        {
            _presenter.Refresh();
        }
    }
}