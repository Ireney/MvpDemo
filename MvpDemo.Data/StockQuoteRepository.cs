using System.Linq;
using MvpDemo.Domain;

namespace MvpDemo.Data
{
    public class StockQuoteRepository : IStockQuoteRepository
    {
        private readonly IQuoteDataContext _dataContext;

        public StockQuoteRepository(IQuoteDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public StockInfo[] GetQuotes(string symbols)
        {
            return _dataContext.GetQuotes(symbols).ToArray();
        }

        public string GetQuoteProvider()
        {
            return _dataContext.ProviderName;
        }
    }
}