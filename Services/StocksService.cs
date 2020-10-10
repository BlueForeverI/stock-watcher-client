using Microsoft.Extensions.Configuration;
using StockWatcherClient.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StockWatcherClient.Services
{
    public class StocksService
    {
        private string apiUrl;
        private HttpClient httpClient;

        public StocksService(HttpClient httpClient, IConfiguration configuration)
        {
            this.apiUrl = configuration.GetValue<string>("apiUrl");
            this.httpClient = httpClient;
        }

        public async Task<List<Stock>> GetStocks()
        {
            return await this.httpClient.GetFromJsonAsync<List<Stock>>(this.apiUrl + "/stocks");
        }

        public async Task<List<Stock>> FindStocks(string query)
        {
            return await this.httpClient.GetFromJsonAsync<List<Stock>>(this.apiUrl + $"/stocks?query={query}");
        }

        public async Task<List<TrendingStock>> GetTrendingStocks()
        {
            return await this.httpClient.GetFromJsonAsync<List<TrendingStock>>(
                this.apiUrl + "/stocks/trending");
        }

        public async Task AddStock(int stockId, int userId)
        {
            var url = $"{this.apiUrl}/users/{userId}/stocks";
            var content = JsonContent.Create(new { Id = stockId });
            await this.httpClient.PostAsync(url, content);
        }

        public async Task<List<WatchlistStock>> GetWatchList(int userId)
        {
            var url = $"{this.apiUrl}/users/{userId}/watchlist";
            return await this.httpClient.GetFromJsonAsync<List<WatchlistStock>>(url);
        }

        public async Task RemoveFromWatchlist(int userId, int stockId)
        {
            var url = $"{this.apiUrl}/users/{userId}/stocks/{stockId}";
            await this.httpClient.DeleteAsync(url);
        }
    }
}
