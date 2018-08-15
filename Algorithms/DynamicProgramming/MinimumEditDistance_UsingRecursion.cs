using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparation.DynamicProgramming
{

    /*Algorithm Without Dynamic programming
    ---------------------------------------
    1. If x represents the position of xth character in the string A and y represents the position of yth character in the string B
    the minimum cost of converting x characters of String A to y characters of string B i.e.f(x, y) = Min((f(x-1, y-1) + ReplaceCost(x, y)), f(x-1, y) + 1, f(x, y-1) + 1)

    This means String A of length X can be converted to String B of length Y as follows
    1. if A[x] == B[y]
        f(x, y) = f(x-1, y-1) (i.e.same as cost of converting x-1 characters of A to y-1 characters of B)
    2. if A[x] != B[y]
        Then find minimum of following three operations

            f(x-1, y-1) i.e.Replace A[x] with B[y] and Strings are Same

            f(x, y-1) i.e.Delete B[y] and Strings are same

            f(x-1, y) i.e.Insert A[x] at the end of string B and strings are same


    Recurse through this for the lenght of both the strings

    Code Without Dynamic Programming (C#)
    ----------------------------------- */
    public class MinimumEditDistanceWithoutDP
    {
        public static int MinimumEditDistance(char[] A, char[] B, int i, int j)
        { 
            if (i < 0)
                return (j + 1) * 1;

            if (j < 0)
                return (i + 1) * 1;

            return Min(MinimumEditDistance(A, B, i - 1, j - 1) + (A[i] == B[j] ? 0 : 1), // Replace
                            MinimumEditDistance(A, B, i, j - 1) + 1, // Delete
                            MinimumEditDistance(A, B, i - 1, j) + 1); // Add
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
            string A = "Gunjan Agarwal";
            string B = "Gunman Sabarwal";

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
