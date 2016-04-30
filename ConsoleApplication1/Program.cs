using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordSharp;
using DiscordSharp.Objects;

namespace WeloDiscordBot
{
    class Program
    {
        private static  DiscordClient bot;

        static void Main(string[] args)
        {

            
            
            #region SettingUp
            bot = new DiscordClient();
            //Removed and changed password
            MessageHandler.bot = bot;

            #region ConnectionDelegate
            bot.Connected += Logger.LogConnection;
            bot.Connected += ClientConnected;
            #endregion

            #region PVTMSSGDelegate
            bot.PrivateMessageReceived += Logger.LogPrivateMessage;
            bot.PrivateMessageReceived += MessageHandler.HandlePrivateMessage;
            #endregion


            #region PUBMSGDelegate
            bot.MessageReceived += Logger.LogPublicMessage;
            bot.MessageReceived += MessageHandler.HandlePublicMessage;

            #endregion

            string loginAnswer = bot.SendLoginRequest();
            //DEBUG Console.WriteLine(loginAnswer);
            bot.Connect();

            #endregion
            Console.ReadLine();
            bot.Logout();
            
        }

        public static void ClientConnected(object sender, DiscordConnectEventArgs e)
        {
            List<DiscordServer> servers = bot.GetServersList();
            Logger.LogActualServerTree(servers);

            
        }
    }

}
