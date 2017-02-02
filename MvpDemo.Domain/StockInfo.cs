using System;

namespace MvpDemo.Domain
{
    public class StockInfo
    {
        public string Company { get; set; }
        public string CurrentQuote { get; set; }
        public string Change { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
