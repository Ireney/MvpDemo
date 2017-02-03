using System;
using System.Collections.Generic;
using MvpDemo.Domain;
using MvpDemo.Presentation.StockQuote;

namespace MvpDemo.Web
{
    public partial class DefaultView : ViewBase<IStockQuotePresenter<IStockQuoteView>, IStockQuoteView>, IStockQuoteView
    {
        protected override void PageLoad(){}

        public IList<StockInfo> Quotes
        {
            get { return GridView1.DataSource as IList<StockInfo>; }
            set
            {
                GridView1.DataSource = value;
                GridView1.DataBind();
            }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string Symbols
        {
            get { return txtSymbols.Text; }
            set { txtSymbols.Text = value; }
        }

        protected void RefreshClick(object sender, EventArgs e)
        {
            Presenter.Refresh();
        }

        protected void RedirectClick(object sender, EventArgs e)
        {
            Presenter.Redirect();
        }
    }
}