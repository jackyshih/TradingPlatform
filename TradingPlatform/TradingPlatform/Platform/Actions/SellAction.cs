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
    public class SellAction : IAction
    {
        private string share;
        private int quantity;
        public void Handle(IAccount account, MarketDataManager marketDataManager)
        {
            double price = marketDataManager.GetPrice(share);
            if (price > 0)
                account.SellStock(share, quantity, marketDataManager.GetPrice(share));
        }

        public bool ParseParameters(string parameters)
        {
            string[] values = parameters.Split(',');
            if (values.Length != 2)
            {
                MessageUtil.ShowMessage("Invalid Parameter for Sell stocks, Sell(share,quantity)");
                return false;
            }
            try
            {
                quantity = int.Parse(values[1].Trim());
                if (quantity <= 0)
                {
                    MessageUtil.ShowMessage("Quantity must be integery > 0");
                    return false;
                }
            }
            catch (OverflowException e)
            {
                MessageUtil.ShowMessage("Invalid Parameter for Sell stocks, quantity too big or too small, Sell(share,quantity) - quantity must be integer > 0");
                return false;
            }
            catch (Exception e)
            {
                MessageUtil.ShowMessage("Invalid Parameter for Sell stocks, Sell(share,quantity) - quantity must be integer > 0");
                return false;
            }
            share = values[0].Trim();
            return true;
        }
    }
}
