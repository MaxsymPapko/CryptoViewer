using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CryptoViewer.Models
{
    using System.Text.Json.Serialization;

    public class MarketInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Market
    {
        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("target")]
        public string Target { get; set; }

        [JsonPropertyName("last")]
        public decimal Last { get; set; }

        [JsonPropertyName("trade_url")]
        public string TradeUrl { get; set; }

        [JsonPropertyName("market")]
        public MarketInfo MarketInfo { get; set; }
    }

}
