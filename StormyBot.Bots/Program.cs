using StormyBot.Bots;
using System;

namespace StormyBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            //var pointhandler = new PointHandler();
            //pointhandler.Reader();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
