using System.Collections.Generic;
using MvpDemo.Domain;

namespace MvpDemo.Presentation
{
    public interface IDefaultView
    {
        IList<StockInfo> Quotes { get; set; }
        string Message { get; set; }
        string Symbols { get; set; }
    }
}