using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordSharp;
using DiscordSharp.Events;
using DiscordSharp.Objects;

namespace WeloDiscordBot
{
    class Logger
    {
        public static void LogConnection(object sender, DiscordConnectEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[CONNECTED]" + e.User.Username);
            Console.ResetColor();
        }

        public static void LogPrivateMessage(object sender, DiscordPrivateMessageEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[PRIVMSG]"+e.Author.Username+":"+e.Message);
            Console.ResetColor();
        }

        public static void LogActualServerTree(IList<DiscordServer> servers)
        {
            if (servers != null)
            {
                foreach(DiscordServer server in servers)
                {
                    LogServerInfo(server);
                    List<DiscordChannel> channels = server.Channels;
                    LogChannels(channels);

                }


              }
        }

        public static void LogPublicMessage(object sender, DiscordMessageEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("[PUBMSG]{"+e.Channel.Name+"}"+e.Author.Username+":"+e.MessageText);
            Console.ResetColor();
        }

        public static void LogRequestCommand(string command, string username, string spareString)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("["+command+"]" + username + " other details:" +spareString);
            Console.ResetColor();
        }

        private static void LogChannels(List<DiscordChannel> channels)
        {
            if (channels != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (DiscordChannel singleChannel in channels)
                {
                    Console.WriteLine("├"+singleChannel.Name);
                    
                }
                Console.ResetColor();
            }
        }

        private static void LogServerInfo(DiscordServer server)
        {
            if (server != null)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("┬Server: " + server.Name+"\t Hosted into:"+server.Region);

                Console.ResetColor();
                
            }
        }
    }
}
