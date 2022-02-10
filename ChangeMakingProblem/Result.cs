using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMakingProblem
{
    class Result
    {
        /*
         *   Coin Changing Problem
         *   
         *   Input
         *         List<int> coins - coins denominations ( value of each possible coin )
         *         k - amount to make change for
         *         
         *   OutPut
         *   
         *         int m - minimum number of coins to make that change
         */
        public static int CoinChange(List<int> coins, int k)
        {
            // Build an array to memorize previus solutions - from 0 to k
            int[] dp = new int[k + 1];

            // Initialize array. Position 0 stays with default zero. All others init with infinite ( max number ) meaning no possible was achieved at all
            for (int i = 1; i <= k; i++)
                dp[i] = int.MaxValue;

            // Now lets build the dp Memo array for all intermediate sub problems, the sub amounts from 1 to k. The testing amount is: a
            for ( int a=1; a <=k; a++)
            {
                // Now we will se if we can make change for this amount, testing all coins we have
                foreach ( int coin in coins)
                {
                    // Only test coins if coin amount is lower or equal the coin value
                    if ( a >= coin)
                        // For a given amount, if we have to use the given coin, we subtract the coin value from the amount, and look at our table how many coins we already computed are needed for that value. Plus one for the current coin. And if this is less then we found before, we save it.
                        dp[a] = Math.Min(dp[a], 1 + dp[a - coin]);
                }
            }

            // Finally, our result will be found at dp[k]. But its only valid if its lower than int.MaxValue. Otherwise, there was no possible change for this value
            if (dp[k] < int.MaxValue)
                return dp[k];
            else
                return -1;
        }
        /*
         *   Coin Changing Problem
         *   
         *   Input
         *         List<int> coins - coins denominations ( value of each possible coin )
         *         k - amount to make change for
         *         
         *   OutPut
         *   
         *         List<int> - the coins that make that change
         */
        public static List<int> CoinChange2(List<int> coins, int k)
        {
            // Array with List of coins used to make change for all amounts
            List<int>[] change = new List<int>[k+1];
            for (int i = 0; i <= k; i++)
                change[i] = new List<int>();

            // Build an array to memorize previus solutions - from 0 to k
            int[] dp = new int[k + 1];

            // Initialize array. Position 0 stays with default zero. All others init with infinite ( max number ) meaning no possible was achieved at all
            for (int i = 1; i <= k; i++)
                dp[i] = int.MaxValue;

            // Now lets build the dp Memo array for all intermediate sub problems, the sub amounts from 1 to k. The testing amount is: a
            for (int a = 1; a <= k; a++)
            {
                // Now we will se if we can make change for this amount, testing all coins we have
                foreach (int coin in coins)
                {
                    // Only test coins if coin amount is lower or equal the coin value
                    if (a >= coin)
                    {
                        // For a given amount, if we have to use the given coin, we subtract the coin value from the amount, and look at our table how many coins we already computed are needed for that value. Plus one for the current coin. And if this is less then we found before, we save it.
                        if (1 + dp[a - coin] < dp[a])
                        {
                            // Save value
                            dp[a] = 1 + dp[a - coin];

                            // Save list of coins used to make this change
                            change[a] = new List<int>();
                            change[a].AddRange(change[a - coin]);
                            change[a].Add(coin);
                        }
                    }
                }
            }

            // Finally, our result will be found at dp[k]. But its only valid if its lower than int.MaxValue. Otherwise, there was no possible change for this value
            return change[k];

        }
    }
}
