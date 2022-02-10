using System;
using System.Collections.Generic;

namespace ChangeMakingProblem
{
    /*
     * Change Making Problem:
     * 
     *       Given a set of coins denonomination ( with infinite quantities of each denomination )
     *       Given a amout of money to make change
     *       Return a set with the minimum quantity of coins to make that change
     */

    class Program
    {
        public static void Main(string[] args)
        {
            TestChangeMaking();
        }
        static void TestChangeMaking()
        {
            List<int> denominations;
            int k;

            denominations = new() { 1, 3, 4 };
            k = 6;
            Console.WriteLine(String.Join(",", ChangeMakingProblem(denominations, k)));
            Console.WriteLine("Expected: 2, 0, 1");


            denominations = new() { 1, 5, 10, 25 };
            k = 78;
            Console.WriteLine(String.Join(",", ChangeMakingProblem(denominations, k)));
            Console.WriteLine("Expected: 3,0,0,3");

            k = 63;
            Console.WriteLine(String.Join(",", ChangeMakingProblem(denominations, k)));
            Console.WriteLine("Expected: 3,0,1,2");
        }
        /*
         *   Optimal solution with Dynamic Programing
         *   
         *    coins - list of coins denominations
         *    k - amount to make change for
         *   
         */
        public static List<int> ChangeMakingProblem(List<int> coins, int k)
        {
            // Square matrix: one row for each denomination, one row for each value up to k
            int[,] m = new int[coins.Count + 1, k + 1];

            // Fill line 0 with "infinite"
            for (int i = 0; i <= k; i++)
                m[0, i] = int.MaxValue;

            // For each row - each coin denomination
            for (int c = 1; c <= coins.Count; c++)
            {
                // For each subvalue ( all values from 1 to k - value we need to make the change )
                for (int r = 1; r <= k; r++)
                {
                    if (coins[c - 1] == r)
                        m[c, r] = 1;

                    else if (coins[c - 1] > r)
                        m[c, r] = m[c - 1, r];

                    else
                        m[c, r] = Math.Min(m[c - 1, r], 1 + m[c, r - coins[c - 1]]);
                }
            }

            List<int> changeList = new List<int>();

            changeList.Add(m[coins.Count,k]);

            return changeList;
        }
        /*
         *    denominations - list of coins denominations
         *    k - amount to make change for
         *    
         *    Suboptimal aproach
         *       Divide amount for the largest denomination, lower or equal to k
         *       Get rest of division, and keep on dividing
         */
        public static List<int> ChangeMakingProblem2(List<int> denominations, int k)
        {

            List<int> result = new List<int>();

            int amount = k;
            int p = denominations.Count - 1;

            while ( amount > 0)
            {
                if ( amount >= denominations[p])
                {
                    result.Add(amount / denominations[p]);
                    amount = amount % denominations[p];
                }
                else
                {
                    result.Add(0);
                }
                p--;
            }

            result.Reverse();
            return result;
        }
    }
}
