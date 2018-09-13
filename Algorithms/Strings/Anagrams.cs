using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Strings
{
    public class Anagrams
    {
        // Only Modifcations allowed. Insertions/Deletions are not allowed
        // Count unequal characters
        // Return -1 if making anagram is not possible (i.e. lenght unequal)
        // Otherwise, return count of modifications required
        public static int MinimumModifcationsToMakeStringAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return -1;
            int modificationsCount = 0;

            //Assuming only 8 bit ASCII characters are allowed
            var characterCount = new int[256];
            for (int i = 0; i < s1.Length; i++)
            {
                characterCount[Convert.ToByte(s1[i])]++;
            }

            for (int i = 0; i <s2.Length; i++)
            {
                if (characterCount[Convert.ToByte(s2[i])] > 0)
                {
                    characterCount[Convert.ToByte(s2[i])]--;
                }
                else
                {
                    modificationsCount++;
                }
            }

            return modificationsCount;
        }

        // Two methods:
        //1. Sort the strings and compare the characters
        //1. If the characterset of strings is small, maintain an array to count charcters. If count matches, strings are anangrams.
        // Can be done using one array
        public static bool AreAnagrams(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            //Method 2 - Assuming only 8 bit ASCII characters are allowed
            var characterCount = new int[256];
            for (int i = 0; i < s1.Length && i < s2.Length; i++)
            {
                characterCount[Convert.ToByte(s1[i])]++;
                characterCount[Convert.ToByte(s2[i])]--;
            }

            for (int i = 0; i < characterCount.Length; i++)
            {
                if (characterCount[i] > 0)
                    return false;
            }

            return true;
        }

        public static void GenerateAnagrams(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                GenerateAnagrams(str.ToCharArray(), 0, str.Length - 1);
            }
            else
            {
                Console.WriteLine("Empty String");
            }
        }

        private static void GenerateAnagrams(char[] str, int start, int end)
        {
            if (start == end)
                Console.WriteLine(str);
            else
            {
                for (int i = start; i <= end; i++)
                {
                    swap(str, start, i);
                    GenerateAnagrams(str, start + 1, end);
                    swap(str, start, i);
                }
            }
        }

        private static void swap(char[] str, int i, int j)
        {
            char temp = str[i];
            str[i] = str[j];
            str[j] = temp;
        }
    }

    public class Driver
    {
        public static void Main()
        {
            bool areAnagrams = Anagrams.AreAnagrams("1230294820", "1320294820");
            Console.WriteLine(areAnagrams);
            int modificationsToMakeAnagrams = Anagrams.MinimumModifcationsToMakeStringAnagram("ddck", "cedm");
            Console.WriteLine(modificationsToMakeAnagrams);
            Anagrams.GenerateAnagrams("abcd");
            Console.Read();
        }
    }
}
