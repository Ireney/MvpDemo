using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MvpDemo.Domain;

namespace MvpDemo.Services
{
    public class RemoteQuoteService : IQuoteService
    {
        private readonly HttpClient _stockQuotesClient;

        public RemoteQuoteService(HttpClient stockQuotesClient)
        {
            _stockQuotesClient = stockQuotesClient;
        }

        public IList<StockInfo> GetQuotes(string symbols)
        {
            return GetQuotesAsync(symbols).Result;
        }

        public string GetProviderName()
        {
            return GetProviderNameAsync().Result;
        }

        private async Task<IList<StockInfo>> GetQuotesAsync(string symbols)
        {
            IList<StockInfo> quotes = null;
            
            var response = await _stockQuotesClient.GetAsync($"api/stockquotes/{symbols}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                quotes = await response.Content.ReadAsAsync<IList<StockInfo>>();
            }
            
            return quotes;
        }

        private async Task<string> GetProviderNameAsync()
        {
            string providerName = null;
            
            var response = await _stockQuotesClient.GetAsync($"api/stockquotes").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                providerName = await response.Content.ReadAsAsync<string>();
            }

            return providerName;
        }
    }
}