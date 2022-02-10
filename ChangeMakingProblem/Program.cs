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
            Console.WriteLine(String.Join(",", ChangeMakingProblem1(denominations, k)));
            Console.WriteLine("Expected: 2, 0, 1");


            denominations = new() { 1, 5, 10, 25 };
            k = 78;
            Console.WriteLine(String.Join(",", ChangeMakingProblem1(denominations, k)));
            Console.WriteLine("Expected: 3,0,0,3");

            k = 63;
            Console.WriteLine(String.Join(",", ChangeMakingProblem1(denominations, k)));
            Console.WriteLine("Expected: 3,0,1,2");
        }
        /*
         *    denominations - list of coins denominations
         *    k - amount to make change for
         *    
         *    Suboptimal aproach
         *       Divide amount for the largest denomination, lower or equal to k
         *       Get rest of division, and keep on dividing
         */
        public static List<int> ChangeMakingProblem1(List<int> denominations, int k)
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
