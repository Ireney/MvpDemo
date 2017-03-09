using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvpDemo.Presentation.Navigation;
using NSubstitute;

namespace MvpDemo.Presentation.Tests
{
    [TestClass]
    public class NavigatorTests
    {
        private INavigationRouteStrategy _routeStrategy;
        private Navigator _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _routeStrategy = Substitute.For<INavigationRouteStrategy>();
            _sut = new Navigator(_routeStrategy);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _routeStrategy = null;
            _sut = null;
        }

        [TestMethod]
        public void ShouldNavigateToSpecifiedView_WithNoArgument_OnGoTo()
        {
            //Arrange
            
            //Act
            _sut.Goto(NavigationTarget.About);

            //Assert
            _routeStrategy.Received(1).Goto(NavigationTarget.About, null);
        }

        [TestMethod]
        public void ShouldNavigateToSpecifiedView_WithArguments_OnGoTo()
        {
            //Arrange
            var navigationParameter = new SomeParameterType();

            //Act
            _sut.Goto(NavigationTarget.About, navigationParameter);

            //Assert
            _routeStrategy.Received(1).Goto(NavigationTarget.About, navigationParameter);
        }
    }
    internal class SomeParameterType {}
}