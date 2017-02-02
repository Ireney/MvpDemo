using System.Collections.Generic;
using MvpDemo.Domain;

namespace MvpDemo.Data
{
    public interface IQuoteDataContext
    {
        string ProviderName { get; }
        IList<StockInfo> GetQuotes(string symbols);
    }
}