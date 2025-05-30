using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoViewer.Models;
using System.Windows;

namespace CryptoViewer.Services
{
    public class CoinGeckoService
    {
        private readonly HttpClient _httpClient;

        public CoinGeckoService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
        }

        public async Task<List<Currency>> GetTopCurrenciesAsync(int count)
        {
            var currencies = new List<Currency>();

            try
            {
                string url = $"https://api.coingecko.com/api/v3/coins/markets" +
                             $"?vs_currency=usd&order=market_cap_desc&per_page={count}&page=1&sparkline=false";

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"⚠ API помилка: {response.StatusCode}");
                    return currencies;
                }

                var json = await response.Content.ReadAsStringAsync();

                currencies = JsonSerializer.Deserialize<List<Currency>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (currencies == null)
                {
                    MessageBox.Show("⚠ Не вдалося десеріалізувати JSON.");
                    return new List<Currency>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Виняток при запиті: " + ex.Message);
            }

            return currencies;
        }

    }
}