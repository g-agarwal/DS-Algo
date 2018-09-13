using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.DynamicProgramming
{
//    Subset Sum Problem
//    ******************

//1. Given a set of numbers, find if a sum can be formed using a subset of numbers
//Input
//	- Array of numbers in Increasing order A[]
//	- Desired sum to be formed

//Output
//	- True/False

//Algorithm using DP
//1. Create a memoization matrix M[N, Sum] where rows represent the numbers(0 - N) and rows represent the sum(0, 1, 2 ---- Sum) - Sum column need to have all possible values of sum starting from 0 - sum.
// For DP solution the space required to create the memoization matrix will be really huge if sum is a large number

//2. Fill First row of matrix
//    M[0, 0] = True, M[0, 1] - M[0, Sum] = False // As {0}, can be only used to form Sum = 0
//3. For Filling rest of the matrix follow following rules
//    M[i, j] = M[i - 1, j] OR M[i - 1, j - A[i - 1] // I.e. Whether the sum can be formed by excludign new (i.e. ith element) OR Whether the sum can be formed by including ith element
//        // Sum can be formed by including new (i.e. ith element) => Num Element + X = Sum => X = Sum - New Element => The problem boils down to whether we can form this X can be formed by excluding the new element. This should already have been calculated in i -1, j - ith cell of the memoization matrix

// 4.Return the Value of of the required cell from Memoization matrix



// Code using C#
    class SubsetsumProblem
    {
        static bool CanSumBeFormedFromASubset(int sum, int[] A)
        {
            // Create a Memoization Matrix
            int N = A.Length;
            bool[,] M = new bool[N + 1, sum + 1];

            // Initialize first column
            for (int i = 0; i <= N; i++)
            {
                M[i, 0] = true;
            }

            // Initialize first row
            for (int j = 1; j <= sum; j++)
            {
                M[0, j] = false;
            }

            // Fill rest of the memoization matrix

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (j < A[i - 1])
                    {
                        M[i, j] = M[i - 1, j];
                    }
                    else if (j >= A[i - 1])
                    {
                        M[i, j] = (M[i - 1, j] || M[i - 1, j - A[i - 1]]);
                    }
                }
            }

            return M[N, sum];
        }

        // Driver Programer
        public static void Main()
        {
            // Test case
            int[] input = { 1, 3, 5, 7, 12};
            int sum = 10;

            bool var = CanSumBeFormedFromASubset(sum, input);
            Console.Write(var);
            Console.Read();
        }

    }
}
