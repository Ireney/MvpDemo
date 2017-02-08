using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvpDemo.Presentation.Navigation;
using NSubstitute;

namespace MvpDemo.Presentation.Tests
{
    [TestClass]
    public class NavigatorTests
    {
        private INavigationRouteSystem _routeSystem;
        private Navigator _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _routeSystem = Substitute.For<INavigationRouteSystem>();
            _sut = new Navigator(_routeSystem);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _routeSystem = null;
            _sut = null;
        }

        [TestMethod]
        public void ShouldNavigateToSpecifiedView_WithNoArgument_OnGoTo()
        {
            //Arrange
            
            //Act
            _sut.Goto(NavigationTargets.About);

            //Assert
            _routeSystem.Received(1).Goto(NavigationTargets.About, null);
        }

        [TestMethod]
        public void ShouldNavigateToSpecifiedView_WithArguments_OnGoTo()
        {
            //Arrange
            var navigationParameter = new SomeParameterType();

            //Act
            _sut.Goto(NavigationTargets.About, navigationParameter);

            //Assert
            _routeSystem.Received(1).Goto(NavigationTargets.About, navigationParameter);
        }
    }
    internal class SomeParameterType {}
}