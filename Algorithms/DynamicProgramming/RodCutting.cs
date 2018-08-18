using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparation.DynamicProgramming
{
    //    Segments Cutting Problem
    // ************************
    //Problem - A rod of length N
    //          We are allowed to cut the rod in segments of length X, Y, Z ... and each possible segment lenght has an associated profit attached with it

    //          We need to cut the rod such that the profit is maximized

    //Input - Integer N - Denoting the rod length

    //        An array A with each element denoting possible segment lenghts

    //        Another array B denoting profit associated with each segement lenght

    //Output - Integer - Denoting Max Profit

    //         Srting - Denoting the segment lengths that are included X + Y + Z...

    //Constraints - An upper limit on N
    //              Allowed segments with a certain range

    //Algorithm using DP
    //******************
    //1. Create a Memoization metrix M[NumSegements + 1, N + 1]
    //    Each represents the allowed segment length starting from 0
    //	Each column represents the length from 0 to N

    //    M[i, j] Represent the maxium profit that can be made by cutting the rod of length j using segments A[i - 1] which has an associated profit of B[i - 1]

    //2. M[0, j] = 0 for all j --> This indicates that max profit that can be made by taking a segemetn of length 0 and trying to form a rods of lenght 0 - N with it
    //3. M[i, 0] = 0 for all i --> max profit that can be made by using segments of lenght A[0] - A[NumSegements - 1] and trying to form a rod of lenght 0 with them

    //4. For(1 <= i <= NumSegements ) and(1 =< j <= N)

    //    M[i, j] = (Max of profit by excluding the new segment, Max of profit by including the new segment)
    //	i.e.M[i, j] = Max(M[i - 1, j], M[i, j - A[i - 1]])

    //Code using C#
    //*************
    public class RodCutting
    {
        public static int FindMaxProfit(int N, int[] A, int[] B)
        {
            int numSegments = A.Length;

            int[,] M = new int[numSegments + 1, N + 1];

            // Initialize first row and column
            for (int i = 0; i <= N; i++)
            {
                M[0, i] = 0;
            }

            for (int j = 0; j <= numSegments; j++)
            {
                M[j, 0] = 0;
            }

            for (int i = 1; i <= numSegments; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (A[i - 1] > j)
                    {
                        M[i, j] = M[i - 1, j];
                    }
                    else if (A[i - 1] <= j)
                    {
                        M[i, j] = Math.Max(M[i - 1, j], M[i, j - A[i - 1]] + B[i - 1]);
                    }

                }

            }

            return M[numSegments, N];
        }

        public static void Main()
        {
            // Test case
            int[] possibleSegmentLengths = { 1, 2, 3, 4 };
            int[] profitsAssociatedWithsegments = { 2, 5, 9, 8 };
            int length = 7;

            int var = FindMaxProfit(length, possibleSegmentLengths, profitsAssociatedWithsegments);
            Console.Write(var);
            Console.Read();
        }

    }
   
}
