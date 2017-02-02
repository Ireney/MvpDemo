using System.Collections.Generic;
using MvpDemo.Domain;

namespace MvpDemo.Services
{
    public interface IQuoteService
    {
        IList<StockInfo> GetQuotes(string symbols);
        string GetProviderName();
    }
}
