using System;
using System.IO;

namespace StormyBot
{
    public class PointHandler
    {
        public void Reader()
        {
            string filepath = @"Z:\StormyBot\StormyBot\StormyBot.Bots\Storage\StormyPoints.txt";
            string[] lines = File.ReadAllLines(filepath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
