using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAlgo
{
    //Find the length of minimum sub array with maximum degree in an array.
    //The maximum degree of an array is the count of element with maximum frequency.For example, consider the example { 2, 2, 1, 2, 3, 1, 1}
    //the min sub-array length is 4 as 2 has the maximum degree and the smallest sub array which has degree 3 is {2, 2, 1, 2}

    class FrequencyWithStartAndEndIndex
    {
        public int frequency;
        public int start;
        public int end;
    }   

    class SubArraywithMaxDegree
    {
        public static int LenghtOfSubArrayWithMaxDegree(int[] array)
        {
            var frequencyWithStartAndEndIndexMap = new Dictionary<int, FrequencyWithStartAndEndIndex>();

            for (int i = 0; i < array.Length; i++)
            {
                if (frequencyWithStartAndEndIndexMap.ContainsKey(array[i]))
                {
                    var value = frequencyWithStartAndEndIndexMap[array[i]];
                    value.frequency++;
                    value.end = i;
                }
                else
                {
                    var value = new FrequencyWithStartAndEndIndex();
                    value.frequency = 1;
                    value.start = i;
                    value.end = i;
                    frequencyWithStartAndEndIndexMap[array[i]] = value;
                }
            }

            var maxFrequency =  frequencyWithStartAndEndIndexMap.Max(x => x.Value.frequency);
            var minlength = -1;
            foreach (var keyValuePair in frequencyWithStartAndEndIndexMap)
            {
                if (keyValuePair.Value.frequency == maxFrequency)
                {
                    int length = (keyValuePair.Value.end - keyValuePair.Value.start) + 1;
                    if (minlength == -1)
                        minlength = length;
                    else
                        minlength = Math.Min(minlength, length);

                }
            }

            return minlength;
        }
    }

    public class Driver
    {
        public static void Main()
        {
            int[] array = { 1, 1, 1, 2, 3, 4, 2, 2, 3, 3};
            int val = SubArraywithMaxDegree.LenghtOfSubArrayWithMaxDegree(array);
        }
    }
}
