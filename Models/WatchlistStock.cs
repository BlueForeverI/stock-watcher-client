
namespace StockWatcherClient.Models
{
    public class WatchlistStock
    {
        public int StockId { get; set; }
        public StockPrice Price { get; set; }
        public QuoteTypeData QuoteType { get; set; }

        public class StockValue
        {
            public decimal Raw { get; set; }
            public string Fmt { get; set; }
        }

        public class QuoteTypeData
        {
            public string Symbol { get; set; }
            public string LongName { get; set; }
        }

        public class StockPrice
        {
            public StockValue RegularMarketPrice { get; set; }
            public StockValue RegularMarketChangePercent { get; set; }
        }
    }
}
