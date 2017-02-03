using System.Collections.Generic;
using MvpDemo.Domain;

namespace MvpDemo.Presentation.StockQuote
{
    public interface IStockQuoteView : IView
    {
        IList<StockInfo> Quotes { get; set; }
        string Message { get; set; }
        string Symbols { get; set; }
    }
}