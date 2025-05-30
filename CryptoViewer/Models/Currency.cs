using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoViewer.Models
{
    public class Currency
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("current_price")]
        public decimal CurrentPrice { get; set; }


        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonPropertyName("total_volume")]
        public decimal TotalVolume { get; set; }


        [JsonPropertyName("price_change_percentage_24h")]
        public decimal PriceChangePercentage24h { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }





    }
}
