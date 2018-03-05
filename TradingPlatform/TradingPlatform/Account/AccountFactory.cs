using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.Account
{
    public class AccountFactory
    {
        public static IAccount createAccount(string accountName)
        {
            //for simplcity only return NormalAccount
            //there should be link to different account by accountName for real life implementation
            return new NormalAccount();
        }
    }
}
