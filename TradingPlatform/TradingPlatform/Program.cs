using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.Platform;
using TradingPlatform.Platform.Messages;

namespace TradingPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            TradePlatform platform = new TradePlatform();
            platform.InitMarketData();
            platform.CreateSession();
            string command = "";
            Console.WriteLine("Welcome to TradingPlatform");
            MessageUtil.ShowMenu();

            while (true)
            {
                command = Console.ReadLine();
                if (command!=null && !command.ToLower().Equals("exit") && command.Trim().Length>0)
                {
                    platform.HandleCommand(command);
                }
                else if (command != null && command.ToLower().Equals("exit"))
                {
                    break;
                }
            }

           

        }
    }
}
