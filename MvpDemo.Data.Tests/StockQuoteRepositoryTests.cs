using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace MvpDemo.Data.Tests
{
    [TestClass]
    public class StockQuoteRepositoryTests
    {
        private StockQuoteRepository _sut;
        private IQuoteDataContext _dataContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _dataContext = Substitute.For<IQuoteDataContext>();
            _sut = new StockQuoteRepository(_dataContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _dataContext = null;
            _sut = null;
        }

        [TestMethod]
        public void ShouldGetQuotes_FromDataContext_OnGetQuotes()
        {
            //Act
            _sut.GetQuotes("AAPL");

            //Assert
            _dataContext.Received().GetQuotes("AAPL");
        }
    }
}
