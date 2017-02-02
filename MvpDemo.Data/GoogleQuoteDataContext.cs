using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using MvpDemo.Domain;
using Newtonsoft.Json.Linq;

namespace MvpDemo.Data
{
    public class GoogleQuoteDataContext : IQuoteDataContext
    {
        private const string UrlBase = "http://finance.google.com/finance/info?client=ig&q={0}";

        public string ProviderName => "Google Finance";

        public IList<StockInfo> GetQuotes(string symbols)
        {
            return FindQuoteInfo(symbols);
        }

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

            var json = response.TrimStart('\n','/').Trim();

            Debug.WriteLine(json);

            dynamic parsedResponse = JArray.Parse(json);

            foreach (var result in parsedResponse)
            {
                var stock = new StockInfo
                {
                    Company = result.t,
                    CurrentQuote = result.l,
                    Date =  new DateTime((int)result.lt_dts.Value.Year, (int)result.lt_dts.Value.Month, (int)result.lt_dts.Value.Day).ToShortDateString(),
                    Time = result.ltt,
                    Change = result.c
                };

                data.Add(stock);
            }

            return data.ToArray();
        }
    }
}