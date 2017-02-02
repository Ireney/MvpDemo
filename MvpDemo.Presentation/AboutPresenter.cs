using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpDemo.Presentation
{
    public class AboutPresenter : IAboutPresenter
    {
        private readonly INavigator _navigator;
        private IAboutView _view;

        public AboutPresenter(INavigator navigator)
        {
            _navigator = navigator;
        }

        public void Present(IAboutView view)
        {
            _view = view;
        }

        public void HandleParameter(object parameter)
        {
           _view.Message = parameter == null ? "[No  value passed]" : parameter as string;
        }

        public void Redirect()
        {
            _navigator.Goto("home");
        }
    }
}
