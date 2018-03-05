using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.Platform.Messages
{
    public class MessageUtil
    {
        public static void ShowMessage(string message, bool showAvailableCommands = false)
        {
            Console.WriteLine(message);

            if (showAvailableCommands)
            {
                ShowMenu();    
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
            }

        }

        public static void ShowMenu()
        {
            Console.WriteLine("=================================================");
            Console.WriteLine();
            Console.WriteLine("Available Commands");
            Console.WriteLine("Buy(share,quantity) - Buy stock, quantity must be positive integer.e.g. Buy(APPL,50)");
            Console.WriteLine("Sell(share,quantity) - Sell stock, quantity must be positive integer. e.g. Sell(APPL,100)");
            Console.WriteLine("ShowPortfolio() - Show all stock holdings with current price");
            Console.WriteLine("UpdateData(share,price) - update current price for stock, e.g. UpdateData(APPL,175.5)");
            Console.WriteLine("exit - quit the application");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
