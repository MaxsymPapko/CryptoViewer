using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Models
{
    public class Currency
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal MarketCap { get; set; }
        public decimal TotalVolume { get; set; }

        public decimal PriceChangePercentage24h { get; set; }

        public string Image { get; set; }





    }
}
