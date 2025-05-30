using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoViewer.Models;


namespace CryptoViewer.Services
{
    public static class CoinGeckoService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Currency>> GetTopCurrenciesAsync(int count = 10)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page={count}&page=1&sparkline=false";
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return new List<Currency>();

            var json = await response.Content.ReadAsStringAsync();
            var currencies = JsonSerializer.Deserialize<List<Currency>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return currencies;
        }
    }
}