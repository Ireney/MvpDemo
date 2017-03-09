using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvpDemo.Data;
using MvpDemo.WebApi.Controllers;
using NSubstitute;

namespace MvpDemo.WebApi.Tests
{
    [TestClass]
    public class StockQuotesControllerTests
    {
        private IStockQuoteRepository _repository;

        private StockQuotesController _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = Substitute.For<IStockQuoteRepository>();
            _sut = new StockQuotesController(_repository)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _repository = null;
            _sut = null;
        }

        [TestMethod]
        public void ShouldGetQuotes_FromRepository_OnGet()
        {
            //Arrange

            //Act
            _sut.Get("AAPL");

            //Assert
            _repository.Received(1).GetQuotes("AAPL");
        }

        [TestMethod]
        public void SHouldGetProviderName_FromRepository_OnGetProviderName()
        {
            //Arrange
            
            //Act
            _sut.GetProviderName();

            //Assert
            _repository.Received(1).GetQuoteProvider();
        }
    }
}