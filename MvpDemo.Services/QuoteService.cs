using System.Collections.Generic;
using MvpDemo.Data;
using MvpDemo.Domain;

namespace MvpDemo.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IStockQuoteRepository _repository;

        public QuoteService(IStockQuoteRepository repository)
        {
            _repository = repository;
        }

        public IList<StockInfo> GetQuotes(string symbols)
        {
            return _repository.GetQuotes(symbols);
        }

        public string GetProviderName()
        {
            return _repository.GetQuoteProvider();
        }
    }
}
