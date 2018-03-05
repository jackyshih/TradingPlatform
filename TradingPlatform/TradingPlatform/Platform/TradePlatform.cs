using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.Account;
using TradingPlatform.MarketData;
using TradingPlatform.Platform.Actions;
using TradingPlatform.Platform.Messages;

namespace TradingPlatform.Platform
{
    public class TradePlatform
    {
        private MarketDataManager marketDataManager;
        private IAccount account;
        public void InitMarketData()
        {
            marketDataManager = new MarketDataManager();
        }

        public void CreateSession()
        {
            account = AccountFactory.createAccount("Normal");
        }

        public void HandleCommand(string command)
        {
            IAction action = ActionManager.GetAction(command);
            if (action != null)
                action.Handle(account, marketDataManager);
        }

    }
}
