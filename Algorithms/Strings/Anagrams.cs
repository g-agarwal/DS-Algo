using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparation.Strings
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

        public static void PrintAllAnagrams(string s1)
        {

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

            Console.Read();
        }
    }
}
