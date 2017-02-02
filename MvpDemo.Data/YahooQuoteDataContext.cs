using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using MvpDemo.Domain;

namespace MvpDemo.Data
{
    public class YahooQuoteDataContext : IQuoteDataContext
    {
        #region Local variables

        private const string UrlBase =
            "http://download.finance.yahoo.com/d/quotes.csv?s={0}&f=sl1d1t1c1ohgvj1pp2owern&d=t";

        #endregion

        public string ProviderName => "Yahoo Finance";

        #region IQuoteDataContext Members

        public IList<StockInfo> GetQuotes(string symbols)
        {
            return FindQuoteInfo(symbols);
        }

        #endregion

        #region Helpers

        private StockInfo[] FindQuoteInfo(string symbols)
        {
            var url = string.Format(UrlBase, symbols);

            string output;
            StreamReader reader;

            var request = WebRequest.Create(url);
            var response = request.GetResponse();

            using (reader = new StreamReader(stream: response.GetResponseStream()))
            {
                output = reader.ReadToEnd();
                reader.Close();
            }

            return ParseResponseToArray(output);
        }

        private StockInfo[] ParseResponseToArray(string response)
        {
            var data = new List<StockInfo>();

            var rows = response.Split(new[] {"\n"},
                StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < rows.Length; i++)
            {
                var tokens = rows[i].Split(',');

                var stock = new StockInfo
                {
                    Company = RemoveQuotes(tokens[16]),
                    CurrentQuote = tokens[1],
                    Date = RemoveQuotes(tokens[2]),
                    Time = RemoveQuotes(tokens[3]),
                    Change = RemoveQuotes(tokens[11])
                };

                data.Add(stock);
            }

            return data.ToArray();
        }

        private static string RemoveQuotes(string originalText)
        {
            originalText = originalText.TrimEnd('\r', '\"');
            return originalText.Substring(1, originalText.Length - 1);
        }

        #endregion
    }
}