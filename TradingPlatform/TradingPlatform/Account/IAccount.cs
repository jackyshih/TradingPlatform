using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.MarketData;
using TradingPlatform.MarketData.Sources;

namespace TradingPlatform.Account
{
    public interface IAccount
    {
        void ShowAccountDetails(MarketDataManager marketData);
        void BuyStock(string symbol, int shares, double price);
        void SellStock(string symbol, int shares, double price);
    }

}
