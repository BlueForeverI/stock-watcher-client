using Microsoft.Extensions.Configuration;
using StockWatcherClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    }
}
