using System;
using System.Collections.Generic;
using System.Text;

namespace StormyBot
{
    class Sorting
    {
        public int levelSorter(string level)
        {
            if (level.Contains("1") == true)
            {
                return 0;
            }
            else if (level.Contains("2a") == true)
            {
                return 1;
            }
            else if (level.Contains("2b") == true)
            {
                return 2;
            }
            else if (level.Contains("3") == true)
            {
                return 3;
            }
            else if (level.Contains("4") == true)
            {
                return 4;
            }
            else if (level.Contains("5") == true)
            {
                return 5;
            }
            else
            {
                return 6;
            }
        }
        public int PeriodSorter(string period)
        {
            int i = Convert.ToInt32(period);

            i--;

            return i;
        }
        public bool YesNoSorter(string user)
        {
            if (user.Contains("y") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string NickNameFix(string nickName, string userName)
        {
            if (nickName == null)
            {
                return StarRemover(userName);
            }
            else
            {
                return StarRemover(nickName);
            }
        }
        public string StarRemover(string name)
        {
            if (name.StartsWith("*") == true)
            {
                return name.Replace("*", "");
            }
            else
            {
                return name;
            }
        }
        public bool MathCheck(string user, string answer)
        {
            if (user.Contains(answer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
