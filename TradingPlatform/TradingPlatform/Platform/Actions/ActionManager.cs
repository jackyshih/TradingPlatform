using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.Platform.Messages;

namespace TradingPlatform.Platform.Actions
{
    public class ActionManager
    {
        
        public static IAction GetAction(string command)
        {
            string cmd = command.Trim().ToLower();
            cmd = cmd.First().ToString().ToUpper() + cmd.Substring(1);
            string actionString = getActionFromCommand(cmd);

            if (actionString.Equals("") || !cmd.EndsWith(")"))
            {
                //invalid command format, ignore
            }
            else
            {

                string parameters = cmd.Substring(cmd.IndexOf("(")+1, cmd.Length - 1 - cmd.IndexOf("(") -1 );

                try
                {
                    string className = "TradingPlatform.Platform.Actions." + actionString + "Action";

                    Type t = Type.GetType(className);
                    if (t != null)
                    {
                        IAction action = (IAction)Activator.CreateInstance(t);
                        bool success = action.ParseParameters(parameters);
                        if (success)
                            return action;
                        else
                            return null;
                    }
                    
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
            MessageUtil.ShowMessage("Invalid Command", true);
            return null;
        }

        private static string getActionFromCommand(string command)
        {
            int actionEndIndex = command.IndexOf("(");
            if (actionEndIndex<0)
            {
                return "";
            }
            return command.Substring(0, actionEndIndex).Trim();
        }
        
    }
}
