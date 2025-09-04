
using System;
using System.Collections.Generic;

namespace test
{
    public class program
    {
        public static void Main(string[] args)
        {
           Console.WriteLine("Press run code to see this in the console!");
            int[] price = [7, 12, 5, 3, 11, 6, 10, 2, 9];
            int[] day = [0, 1, 2, 3, 4, 5, 6, 7, 8];
            int buyday;
            for (int i = 0; i < 9; i++)
            {
                if (price[i] > 11)
                {
                    GetBuyDay(day[i]);
                }
                else if (price[i] < 3)
                {
                    GetSellDay(day[i]);
                }
                else
                { 
                
                };
            }

        }

        public static int GetBuyDay(int a)
        {
            Console.WriteLine(a);
            return a;
        }

        /**
         * Return the day to sell silver on. This day has to be after (greater
         * than) the buy day. The first day has number zero (although this is not
         * a valid sell day). This method is called second, and only once.
         */
        public static int GetSellDay(int a)
        {
            Console.WriteLine(a);
            return a;
        }
    }
}