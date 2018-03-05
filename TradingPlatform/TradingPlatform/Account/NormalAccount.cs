using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.MarketData;
using TradingPlatform.MarketData.Sources;
using TradingPlatform.Platform.Messages;

namespace TradingPlatform.Account
{
    public class NormalAccount : IAccount
    {

        private Dictionary<string, int> details;
        private double purchasingPower;

        public NormalAccount()
        {
            details = new Dictionary<string, int>();
            purchasingPower = 2000000;
        }

        public virtual void ShowAccountDetails(MarketDataManager marketData)
        {
            Dictionary<string, int> result = new Dictionary<string, int>(details);

            MessageUtil.ShowMessage("Current Portfolio (Stock-holding-current price)");
            if (details.Count==0)
            {
                MessageUtil.ShowMessage("No Holding.");
                
            }
            foreach (string stock in details.Keys)
            {
                MessageUtil.ShowMessage(stock + "-" +details[stock] +"-"+marketData.GetPrice(stock));
            }
            MessageUtil.ShowMessage("Remaining Purchasing Power : "+purchasingPower);
        }

        public virtual void BuyStock(string symbol, int shares, double price)
        {
            //if not enough purchasing power, return -1, else deduct the cost from purchasing power and add the shares to the dictionary
            double cost = shares * price;

            if (purchasingPower >= cost)
            {
                if (details.ContainsKey(symbol))
                {
                    details[symbol] += shares;
                }
                else
                {
                    details[symbol] = shares;
                }
                purchasingPower -= cost;
                MessageUtil.ShowMessage("Bought! symbol : " + symbol + ", current position : " + details[symbol] + ", current purchasing power : " + purchasingPower);
                return;
            }
            MessageUtil.ShowMessage("Not enough purchasing power for buying, symbol : " + symbol + ", shares: " + shares +", price : "+price+", purchasing power need : " +cost+ ", current purchasing power : " + purchasingPower);
        }

        public virtual void SellStock(string symbol, int shares, double price)
        {
            //if doesn't have the symbol in portfolio or the portfolio doesn't have enough shares for sell, return -2, else deduct the shares from portfolio and add the amount back to the purchasing power
            if (details.ContainsKey(symbol) && details[symbol] >= shares)
            {
                details[symbol] -= shares;

                purchasingPower += shares * price;

                MessageUtil.ShowMessage("Sold! symbol : " + symbol + ", current position : " + details[symbol] + ", current purchasing power : " + purchasingPower);

                if (details[symbol] == 0)
                    details.Remove(symbol);

                
                return;
            }
            MessageUtil.ShowMessage("Not enough holding for selling, symbol : "+symbol+", current position : "+ (details.ContainsKey(symbol)?details[symbol]:0));            
        }
    }
}
