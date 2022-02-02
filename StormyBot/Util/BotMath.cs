using System;
using System.Collections.Generic;
using System.Text;

namespace StormyBot
{
    class BotMath
    {
        Random rnd = new Random();
        public string[] EasyRandomizer()
        {
            var rando = rnd.Next(0, 3);

            if (rando == 0)
            {
                return Addition();
            }
            else if (rando == 1)
            {
                return Subtraction();
            }
            else if (rando == 2)
            {
                return Multiply();
            }
            else
            {
                return null;
            }
        }
        public string[] Addition()
        {
            var a = rnd.Next(1, 17);
            var b = rnd.Next(1, 17);
            string[] send = new string[] { "what is " + a + " + " + b + " =", Convert.ToString(a + b) };
            return send;
        }
        public string[] Subtraction()
        {
            var a = rnd.Next(1, 17);
            var b = rnd.Next(1, 17);
            string[] send = new string[] { "what is " + a + " - " + b + " =", Convert.ToString(a - b) };
            return send;
        }
        public string[] Multiply()
        {
            var a = rnd.Next(1, 17);
            var b = rnd.Next(1, 17);
            string[] send = new string[] { "what is " + a + " x " + b + " =", Convert.ToString(a * b) };
            return send;
        }
        //
        //i know theres a better way to do this but i dont care cus this works.
        //
        public string[] HardRandomizer()
        {
            var rando = rnd.Next(0, 3);

            if (rando == 0)
            {
                return HardAddition();
            }
            else if (rando == 1)
            {
                return HardSubtraction();
            }
            else if (rando == 2)
            {
                return HardMultiply();
            }
            else
            {
                return null;
            }
        }
        public string[] HardAddition()
        {
            var a = rnd.Next(1, 101);
            var b = rnd.Next(1, 101);
            string[] send = new string[] { "what is " + a + " + " + b + " =", Convert.ToString(a + b) };
            return send;
        }
        public string[] HardSubtraction()
        {
            var a = rnd.Next(1, 101);
            var b = rnd.Next(1, 101);
            string[] send = new string[] { "what is " + a + " - " + b + " =", Convert.ToString(a - b) };
            return send;
        }
        public string[] HardMultiply()
        {
            var a = rnd.Next(1, 51);
            var b = rnd.Next(1, 51);
            string[] send = new string[] { "what is " + a + " x " + b + " =", Convert.ToString(a * b) };
            return send;
        }
    }
}
