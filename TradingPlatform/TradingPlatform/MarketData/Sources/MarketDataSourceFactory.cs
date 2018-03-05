using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.MarketData.Sources
{
    class MarketDataSourceFactory
    {
        private static IMarketDataSource marketDataSource;

        static MarketDataSourceFactory()
        {
            marketDataSource = new MemoryCacheMarketDataSource();
        }

        public static IMarketDataSource GetMarketDataSource()
        {
            return marketDataSource;
        }
    }
}
