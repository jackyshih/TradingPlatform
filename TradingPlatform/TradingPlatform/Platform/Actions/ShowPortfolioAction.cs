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
    public class ShowportfolioAction : IAction
    {
        public void Handle(IAccount account, MarketDataManager marketDataManager)
        {
            account.ShowAccountDetails(marketDataManager);
        }

        public bool ParseParameters(string parameters)
        {
            if (parameters != null && parameters.Trim().Length == 0)
                return true;
            MessageUtil.ShowMessage("Invalid Parameter for ShowPortfolio, ShowPortfolio() - should have no parameters");
            return false;
        }
    }
}
