using MvpDemo.Domain;

namespace MvpDemo.Data
{
    public interface IStockQuoteRepository
    {
        string GetQuoteProvider();
        StockInfo[] GetQuotes(string symbols);
    }
}