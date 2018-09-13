using System;

namespace DSAlgo
{
    class KadanesMaxSumSubArray
    {
        //        Maximum Sum Subarray(Kadane's Algorithm)
        //*****************************************

        //Input - An array containing positive and negative integers
        //Output - Max Sum of the sumbarray (Contiguous elements) and Start and end index of sub array

        //Program C#
        //**********

        public static int FinxMaxLengthSubArray(int[] A, out int startOfSubArray, out int endOfSubArray)
        {
            int maxSoFar = 0;
            int maxEndingHere = 0;
            int start = 0;
            int s = 0;
            int e = 0;

            for (int i = 0; i < A.Length; i++)
            {
                maxEndingHere = maxEndingHere + A[i];

                if (maxSoFar < maxEndingHere)
                {
                    maxSoFar = maxEndingHere;
                    start = s;
                    e = i;
                }

                if (maxEndingHere < 0)
                {
                    maxEndingHere = 0;
                    s = i + 1;
                }
            }

            startOfSubArray = start;
            endOfSubArray = e;

            return maxSoFar;
        }

        public static void Main()
        {
            // Test case
            int[] inputArray = { 4,-3,-2,7, 3,1,-2,-3,4,2,-1,-3,-1,3,1,2 };
            int startOfSubArray;
            int endOfSubArray;
            int var = FinxMaxLengthSubArray(inputArray, out startOfSubArray, out endOfSubArray);
            Console.WriteLine("Max Sum of SubArray is: " + var);
            Console.WriteLine("The Aray is");
            for (int i = startOfSubArray; i <= endOfSubArray; i++)
            {
                Console.WriteLine(inputArray[i]);
            }
            Console.Read();
        }
    }
}
