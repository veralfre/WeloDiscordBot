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
    class MessageHandler
    {
        public static DiscordClient bot { get; set; }
        public static void HandlePrivateMessage(object sender, DiscordPrivateMessageEventArgs e)
        {
            DiscordMember author = e.Author;
            string message = e.Message;

            if (message.StartsWith("!"))
            {
                /*CommandSection*/
                string[] splits = message.Split(' ');
                if (splits.Length > 0)
                {
                    string command = splits[0];
                    if (command.ToLower().Equals("!join"))
                    {
                        if (splits.Length > 1)
                        {
                            string link = splits[1];
                            string inviteCode = link.Split('/').Length == 3 ? link.Split('/')[3] : "0000";
                            Logger.LogRequestCommand("JOIN", e.Author.Username,inviteCode);
                            if (bot != null)
                            {
                                bot.AcceptInvite(link);
                                
                            }
                        }

                        e.Author.SendMessage("Tried to join the Server, see you there!");
                        Logger.LogActualServerTree(bot.GetServersList());
                    }
                    if (command.ToLower().Equals("!echo"))
                    {
                        string toEcho = e.Message.Substring(6);
                        Logger.LogRequestCommand("ECHO", e.Author.Username, toEcho);
                        e.Author.SendMessage(toEcho);
                    }



                }
             }


        }

        public static void HandlePublicMessage(object sender, DiscordMessageEventArgs e)
        {
           /*To be implemented*/ 
        }
    }
}
