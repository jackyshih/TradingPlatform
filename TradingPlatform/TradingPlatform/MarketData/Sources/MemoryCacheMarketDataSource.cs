using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.Platform.Messages;

namespace TradingPlatform.MarketData.Sources
{
    public class MemoryCacheMarketDataSource : IMarketDataSource
    {

        private Dictionary<string, double> priceCache = new Dictionary<string, double>();
        public MemoryCacheMarketDataSource()
        {
            priceCache["appl"] = 175.0;
            priceCache["msft"] = 92.85;
        }

        double IMarketDataSource.GetPrice(string symbol)
        {
            if (priceCache.ContainsKey(symbol.Trim()))
            {
                return priceCache[symbol];
            }
            else
            {
                MessageUtil.ShowMessage("Not market data for "+symbol);
            }
            return -1;
        }

        void IMarketDataSource.SetPrice(string symbol, double price)
        {
            if (price > 0)
            {
                priceCache[symbol.Trim()] = price;

                MessageUtil.ShowMessage("price for " + symbol + " updated to " + price);
            }
            else
            {
                MessageUtil.ShowMessage("Invalid price for "+symbol+", price "+price);
            }
        }

    }
}
