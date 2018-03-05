using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.MarketData.Sources
{
    public interface IMarketDataSource
    {
        double GetPrice(string symbol);
        void SetPrice(string symbol, double price);
    }
}
