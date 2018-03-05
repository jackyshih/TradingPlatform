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
    public class UpdatedataAction : IAction
    {
        private string symbol;
        private double price=0;

        public void Handle(IAccount account, MarketDataManager marketDataManager)
        {
            marketDataManager.SetPrice(symbol, price);
        }

        public bool ParseParameters(string parameters)
        {
            string[] values = parameters.Split(',');
            if (values.Length!=2)
            {
                MessageUtil.ShowMessage("Invalid Parameter for UpdateData, UpdateData(share,price)");
                return false;
            }
            try
            {
                price = double.Parse(values[1].Trim());
                if (price <= 0.0)
                {
                    MessageUtil.ShowMessage("price must be > 0");
                    return false;
                }
            }
            catch (OverflowException e)
            {
                MessageUtil.ShowMessage("Invalid Parameter for UpdateData, price too big or small, UpdateData(share,price) - price must be number > 0");
                return false;
            }
            catch (Exception e)
            {
                MessageUtil.ShowMessage("Invalid Parameter for UpdateData, UpdateData(share,price) - price must be number > 0");
                return false;
            }
            symbol = values[0].Trim();
            return true;
        }
    }
}
