using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvpDemo.Domain;
using MvpDemo.Presentation.Navigation;
using MvpDemo.Presentation.StockQuote;
using MvpDemo.Services;
using NSubstitute;

namespace MvpDemo.Presentation.Tests
{
    [TestClass]
    public class StockQuotePresenterTests
    {
        private IQuoteService _quoteService;
        private INavigator _navigator;
        private IStockQuoteView _defaultView;
        private StockQuotePresenter _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _quoteService = Substitute.For<IQuoteService>();
            _navigator = Substitute.For<INavigator>();
            _sut = new StockQuotePresenter(_quoteService, _navigator);

            _defaultView = Substitute.For<IStockQuoteView>();
            _sut.Bind(_defaultView);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _quoteService = null;
            _navigator = null;
            _defaultView = null;
            _sut = null;
        }

        [TestMethod]
        public void ShouldGetQuotes_FromService_OnRefresh()
        {
            //Arrange
            _defaultView.Symbols.Returns("AAPL");

            //Act
            _sut.Refresh();

            //Assert
            _quoteService.Received(1).GetQuotes("AAPL");
        }

        [TestMethod]
        public void ShouldUpdateView_WithQuotes_OnRefresh()
        {
            //Arrange
            var quotes = new List<StockInfo>
            {
                new StockInfo { Change = "4", Company = "Apple", CurrentQuote = "120", Date = "01/01/01", Time = "12:00:00" },
                new StockInfo { Change = "1", Company = "Microsoft", CurrentQuote = "40", Date = "01/01/01", Time = "12:00:00" }
            };

            _defaultView.Symbols.Returns("AAPL,MSFT");
            _quoteService.GetQuotes("AAPL,MSFT").Returns(quotes);
            
            //Act
            _sut.Refresh();

            //Assert
            Assert.AreEqual(quotes, _defaultView.Quotes);
        }

        [TestMethod]
        public void ShouldGetProviderName_FromService_OnRefresh()
        {
            //Act
            _sut.Refresh();

            //Assert
            _quoteService.Received(1).GetProviderName();
        }

        [TestMethod]
        public void ShouldUpdateView_WithMessage_OnRefresh()
        {
            //Arrange
            var quotes = new List<StockInfo>
            {
                new StockInfo { Change = "4", Company = "Apple", CurrentQuote = "120", Date = "01/01/01", Time = "12:00:00" },
                new StockInfo { Change = "1", Company = "Microsoft", CurrentQuote = "40", Date = "01/01/01", Time = "12:00:00" }
            };

            _defaultView.Symbols.Returns("AAPL,MSFT");
            _quoteService.GetQuotes("AAPL,MSFT").Returns(quotes);
            _quoteService.GetProviderName().Returns("FinCorp");

            //Act
            _sut.Refresh();

            //Assert
            Assert.AreEqual("2 quotes found. Provided by FinCorp.", _defaultView.Summary);
        }

        [TestMethod]
        public void ShouldRedirect_ToAboutPage_OnRedirect()
        {
            //Act
            _sut.Redirect();

            //Assert
            _navigator.Received().Goto(NavigationTarget.About, "This text is an argument passed from the presenter.");
        }
    }
}
