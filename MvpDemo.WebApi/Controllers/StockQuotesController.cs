using System.Collections.Generic;
using System.Web.Http;
using MvpDemo.Data;
using MvpDemo.Domain;

namespace MvpDemo.WebApi.Controllers
{
    public class StockQuotesController : ApiController
    {
        private readonly IStockQuoteRepository _repository;

        public StockQuotesController(IStockQuoteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<StockInfo> Get(string id)
        {
            return _repository.GetQuotes(id);
        }

        public string GetProviderName()
        {
            return _repository.GetQuoteProvider();
        }
    }
}
