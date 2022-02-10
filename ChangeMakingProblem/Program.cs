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
            Console.WriteLine("Expected: 0, 2, 0");

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
            // Create an DP Array, from 0 to K ( inclusive )
            int[] dp = new int[k + 1];

            // Position 0 initialized with 0, all others with max (infinite) value
            for (int i = 1; i <= k; i++)
                dp[i] = int.MaxValue;

            // Traverse all sub amounts from 1 to k
            for ( int a=1; a<=k; a++)
            {
                // Traverse all coins
                foreach(int coin in coins)
                {
                    // If given amount is iqual or greater than current coin
                    if ( a >= coin )
                    {
                        // Count ways of make change for this amount, based on last amounts
                        dp[a] = Math.Min(dp[a], 1 + dp[a - coin]);
                    }
                }
            }

            if (dp[k] != int.MaxValue)
                return new List<int>() { dp[k] };
            else
                return new List<int>() { -1 };

        }
        /*
         *    denominations - list of coins denominations
         *    k - amount to make change for
         *    
         *    Suboptimal aproach ( Greedy )
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
