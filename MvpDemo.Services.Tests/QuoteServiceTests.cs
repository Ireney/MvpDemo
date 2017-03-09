using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvpDemo.Data;
using NSubstitute;

namespace MvpDemo.Services.Tests
{
    [TestClass]
    public class QuoteServiceTests
    {
        private IStockQuoteRepository _repository;

        private QuoteService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = Substitute.For<IStockQuoteRepository>();
            _sut = new QuoteService(_repository);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _repository = null;
            _sut = null;
        }

        [TestMethod]
        public void ShouldGetQuotes_FromRepository_OnGetQuotes()
        {
            //Arrange

            //Act
            _sut.GetQuotes("AAPL");

            //Assert
            _repository.Received(1).GetQuotes("AAPL");
        }

        [TestMethod]
        public void ShouldGetProviderName_FromRepository_OnGetProviderName()
        {
            //Arrange

            //Act
            _sut.GetProviderName();

            //Assert
            _repository.Received(1).GetQuoteProvider();
        }
    }
}