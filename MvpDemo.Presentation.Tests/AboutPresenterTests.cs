using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvpDemo.Presentation.About;
using MvpDemo.Presentation.Navigation;
using NSubstitute;

namespace MvpDemo.Presentation.Tests
{
    [TestClass]
    public class AboutPresenterTests
    {
        private INavigator _navigator;
        private IAboutView _aboutView;
        private AboutPresenter _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _navigator = Substitute.For<INavigator>();
            _sut = new AboutPresenter(_navigator);

            _aboutView = Substitute.For<IAboutView>();
            _sut.Bind(_aboutView);
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            _navigator = null;
            _aboutView = null;
            _sut = null;
        }

        [TestMethod]
        public void ShouldReturnNoValuePassed_OnHandleParameter()
        {
            //Act
            _sut.HandleParameter(null);

            //Assert
            Assert.AreEqual("[No value passed]", _aboutView.Message);
        }

        [TestMethod]
        public void ShouldSetViewMessage_WithParameterValue()
        {
            //Act
            _sut.HandleParameter("This is a test");

            //Assert
            Assert.AreEqual("This is a test", _aboutView.Message);
        }

        [TestMethod]
        public void ShouldGoToHome_OnRedirect()
        {
            //Act
            _sut.Redirect();

            //Assert
            _navigator.Received(1).Goto(NavigationTarget.Home);
        }
    }
}
