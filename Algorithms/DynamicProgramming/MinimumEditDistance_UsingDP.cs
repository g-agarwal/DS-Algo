using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparation.DynamicProgramming
{
    class MinimumEditDistanceUsingDP
    {
        //Minimum Edit Distance Using DP
        //------------------------------

        int FindMinimumEditDistance(char[] A, char[] B)
        {
            int[,] M = new int[A.Length + 1, B.Length + 1];

            // Initialize first row and first column

            for (int j = 0; j < A.Length + 1; j++)
            {
                M[0,j] = j;
            }

            for (int i = 0; i < B.Length + 1; i++)
            {
                M[i,0] = i;
            }

            // Start filing the Matrix from first row and first columnn
            for (int i = 1; i < A.Length + 1; i++)
            {
                for (int j = 1; j < B.Length + 1; j++)
                {
                    if (A[i] == B[j])
                    {
                        M[i,j] = M[i - 1,j - 1];
                    }
                    else
                    {
                        M[i,j] = Min(M[i - 1,j - 1], M[i,j - 1], M[i - 1,j]) + 1;
                    }
                }
            }

            return M[A.Length,B.Length];
        }

        // Find min of three numbers
        private static int Min(int a, int b, int c)
        {
            int[] arr = { a, b, c };
            int min = a;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }

        public static void Main()
        {
            string A = "GunjanAgarwal";
            string B = "GunmanSabarwa";

            Stopwatch timer = Stopwatch.StartNew();
            timer.Start();
            int MinEditDistance = 0;
            //if (A[A.Length - 1] != B[B.Length - 1])
            //    MinEditDistance = 1;

            MinEditDistance = MinEditDistance + MinimumEditDistanceWithoutDP.MinimumEditDistance(A.ToCharArray(), B.ToCharArray(), A.Length - 1, B.Length - 1);
            long ElapsedTime = timer.ElapsedMilliseconds;
            timer.Stop();
            Console.WriteLine("Minim Edit Distane between " + A + " " + B + " = " + MinEditDistance);
            Console.WriteLine("Time Taken to compute this Minimum Edit Distance = " + ElapsedTime);
            Console.Read();
        }
    }
}
