using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.Account;
using TradingPlatform.MarketData;
using TradingPlatform.Platform.Messages;

namespace TradingPlatform.Platform.Actions
{
    public interface IAction
    {
        bool ParseParameters(string parameters);
        void Handle(IAccount account, MarketDataManager marketDataManager);
    }
}
