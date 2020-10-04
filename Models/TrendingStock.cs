using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockWatcherClient.Models
{
    public class TrendingStock
    {
        public string Symbol { get; set; }
        public string LongName { get; set; }
        public decimal RegularMarketChangePercent { get; set; }
    }
}
