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
        //public string Image { get; set; } //in case of error, pull down
        public double CurrentPrice { get; set; }
        //public double MarketCap { get; set; }
        //public double PriceChangePercentageFor24H { get; set; }





    }
}
