using System;
using MvpDemo.Presentation.About;

namespace MvpDemo.Web
{
    public partial class AboutView : ViewBase<IAboutPresenter<IAboutView>, IAboutView>, IAboutView
    {
        protected override void PageLoad()
        {
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