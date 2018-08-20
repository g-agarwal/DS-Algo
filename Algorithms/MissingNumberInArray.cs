using System;


namespace Preparation
{
    class MissingElementInArray
    {
        //        Find Missing Number in an Array
        //*******************************

        //Given a list of n-1 integers and these integers are in the range of 1 to n.
        //There are no duplicates in list.One of the integers is missing in the list. Write an efficient code to find the missing integer.

        //Algorithm
        //*********
        //1. Find sum of numbers from  1 - n i.e.SumN
        //2. Add all the numbers in the array i.e.SumArray
        //3. SumN - SumArray is the missing number

        //Code in C#
        //**********

        public static int FindMissingNumber(int[] A)
        {
            int numElementsInArray = A.Length;
            int sumN = (numElementsInArray + 1) * (numElementsInArray + 2) / 2;
            int sumArray = 0;

            for (int i = 0; i < numElementsInArray; i++)
            {
                sumArray = sumArray + A[i];
            }

            return sumN - sumArray;
        }

        public static void Main()
        {
            // Test case
            int[] inputArray = { 1, 2, 4,5, 6, 3, 7, 8, 10 };

            int var = FindMissingNumber(inputArray);
            Console.WriteLine("Missing Number is: " + var);
            Console.Read();
        }
    }
}
