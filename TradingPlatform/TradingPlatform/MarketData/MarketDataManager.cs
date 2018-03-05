using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.MarketData.Sources;

namespace TradingPlatform.MarketData
{
    public class MarketDataManager
    {
        private IMarketDataSource marketDataSource;

        public MarketDataManager()
        {
            marketDataSource = MarketDataSourceFactory.GetMarketDataSource();
        }


        public double GetPrice(string symbol)
        {
            return marketDataSource.GetPrice(symbol);
        }


        public void SetPrice(string symbol, double price)
        {
            marketDataSource.SetPrice(symbol, price);
        }

        public bool validStock(string symbol)
        {
            if (marketDataSource.GetPrice(symbol) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
