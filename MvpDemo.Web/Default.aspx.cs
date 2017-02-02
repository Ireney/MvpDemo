using System;
using System.Collections.Generic;
using System.Web.UI;
using MvpDemo.Domain;
using MvpDemo.Presentation.StockQuote;
using Ninject;

namespace MvpDemo.Web
{
    public partial class _Default : Page, IStockQuoteView
    {
        [Inject]
        public IStockQuotePresenter<IStockQuoteView> StockQuotePresenter { get; set; } = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            StockQuotePresenter.Present(this);
        }

        public IList<StockInfo> Quotes
        {
            get
            {
                return GridView1.DataSource as IList<StockInfo>;
            }
            set
            {
                GridView1.DataSource = value;
                GridView1.DataBind();
            }
        }

        public string Message
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public string Symbols
        {
            get
            {
                return txtSymbols.Text;
            }
            set
            {
                txtSymbols.Text = value;
            }
        }

        protected void RefreshClick(object sender, EventArgs e)
        {
            StockQuotePresenter.Refresh();
        }

        protected void RedirectClick(object sender, EventArgs e)
        {
            StockQuotePresenter.Redirect();
        }
    }
}