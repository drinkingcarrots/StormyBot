using System;
using System.Collections.Generic;
using System.Text;

namespace StormyBot
{
    class GameStuff
    {
        public string RockPaper(int player)
        {
            var rnd = new Random();
            int guess;
            string status;
            guess = rnd.Next(0, 3);

            if (player == guess)
            {
                status = " its a tie";
            }
            else if (player == guess + 1 | player == guess - 2)
            {
                status = " i lost";
            }
            else if (player == guess - 1 | player == guess + 2)
            {
                status = " i win";
            }
            else
            {
                status = "bad code, it broke some how.";
            }

            if (guess == 0)
            {
                return "i chose rock, so i guess" + status;
            }
            else if (guess == 1)
            {
                return "i chose paper, so i guess" + status;
            }
            else if (guess == 2)
            {
                return "i chose Scissors, so i guess" + status;
            }
            else
            {
                return "bad code what";
            }
        }
    }
}
