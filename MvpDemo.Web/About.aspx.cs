using System;
using System.Web.UI;
using MvpDemo.Presentation;
using Ninject;

namespace MvpDemo.Web
{
    public partial class About : Page, IAboutView
    {
        [Inject]
        public IAboutPresenter Presenter
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Present(this);
            Presenter.HandleParameter(Request.QueryString["x"]);
        }

        protected void RedirectClick(object sender, EventArgs e)
        {
            Presenter.Redirect();
        }

        public string Message
        {
            get { return lblParam.Text; }
            set { lblParam.Text = value; }
        }
    }
}