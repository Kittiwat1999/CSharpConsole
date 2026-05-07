using System;
using System.Formats.Asn1;
using System.Globalization;
using System.IO.Pipelines;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = [0,1,0,3,12];
            int[] expected =  [1,3,12,0,0];

            // loging
            Console.WriteLine($"input: [{string.Join(", ", input)}]");
            Console.WriteLine($"expected: [{string.Join(", ", expected)}]");

            Solutions.MoveZeroes(input);
            Console.WriteLine($"result: [{string.Join(", ", input)}]");
            // if (expected == input)
            if (expected.SequenceEqual(input))
            {
                Console.WriteLine("Pass.");
            } else {
                Console.WriteLine("Fail!!");
            }
        }

    }

    static class Solutions
    {
        public static string MergeAlternately(string word1, string word2) {
            var result = new List<Char> {};
            for(int i = 0; i < Math.Max(word1.Length, word2.Length); i++) {
                if(i < word1.Length) {
                    result.Add(word1[i]);
                }

                if(i < word2.Length) {
                    result.Add(word2[i]);
                }
            }

            return string.Join("", result);
        }

        public static string GcdOfStrings(string str1, string str2) {
            for (int i = Math.Max(str1.Length, str2.Length); i > 0; i--) {
                if (str1.Length % i == 0 && str2.Length % i == 0) {
                    string candidate = str1.Substring(0, i);
                    string divides1 = string.Concat(Enumerable.Repeat(candidate, str1.Length / i));
                    string divides2 = string.Concat(Enumerable.Repeat(candidate, str2.Length / i));
                    if (divides1 == str1 && divides2 == str2) {
                        return candidate;
                    }
                }
            }

            return "";
        }

        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
            IList<bool> result = new List<bool> {};
            int extraCandiesNow = candies.Max();
            for(int i = 0; i < candies.Length; i++) {
                bool isExtraCandies = (candies[i] + extraCandies >= extraCandiesNow) ? true : false;
                result.Add(isExtraCandies);
            }

            return result;
        }

        public static bool CanPlaceFlowers(int[] flowerbed, int n) {
            int unFlowerbed = 0;
            int flowerbedLength = flowerbed.Length;
            IList<int> indices = new List<int>();

            for(int i = 0; i < flowerbedLength; i++) {
                if(flowerbed[i] == 1) {
                    indices.Add(i);
                }
            }

            if (indices.Count == 0) {
                return ((flowerbedLength + 1) / 2) >= n;
            }

            if (indices.First() != 0) {
                unFlowerbed += indices.First() / 2; 
            }

            if (indices.Last() != flowerbedLength - 1) {
                unFlowerbed += (flowerbedLength - 1 - indices.Last()) / 2;
            }

            for (int i = 0; i < indices.Count -1; i++) {
                int zeros = indices[i+1] - indices[i] - 1;
                unFlowerbed += (zeros - 1) / 2;
            }

            return unFlowerbed >= n;
        }

        public static string ReverseVowels(string s) {
            string vowels = "aeiouAEIOU";
            IList<char> stringToList = s.ToList();
            int left = 0;
            int right = stringToList.Count - 1;

            while(left < right) {
                while(left < right && !vowels.Contains(stringToList[left])) {
                    left++;
                }
                while(left < right && !vowels.Contains(stringToList[right])) {
                    right--;
                }

                char temp;
                temp = stringToList[left];
                stringToList[left] = stringToList[right];
                stringToList[right] = temp;

                left ++;
                right --;
            }

            return string.Join("", stringToList);
        }

        public static string ReverseWords(string s)
        {
            string[] array = s.Trim().Split(" ");
            IList<string> result = new List<string>();
            for(int i = array.Length - 1; i >= 0; i--)
            {
                if(array[i].Trim() != "")
                {
                    result.Add(array[i].Trim()); 
                }
            }
            return String.Join(" ", result);
        }

        public static bool IncreasingTriplet(int[] nums) {
            int first = int.MaxValue;
            int second = int.MaxValue;

            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] <= first)
                {
                    first = nums[i];
                } else if (nums[i] <= second) {
                    second = nums[i];
                } else {
                    return true;
                }
            }
            return false;
        }
        
        public static int[] ProductExceptSelf(int[] nums) {
            int[] answer = Enumerable.Repeat(1, nums.Length).ToArray();
            int prefix = 1;
            for(int i = 0; i < nums.Length; i++)
            {
                answer[i] = prefix;
                prefix *= nums[i];
            }

            int sufflict = 1;
            for (int j = nums.Length - 1; j >= 0; j--)
            {
                answer[j] *= sufflict;
                sufflict *= nums[j];
            }

            return answer;
        }

        public static int Compress(char[] chars) {
            int charLength = chars.Length;
            int read = 0;
            int write = 0;

            while (read < charLength)
            {
                char ch = chars[read++];
                int count = 1;

                while (read < charLength && ch == chars[read])
                {
                    count++;
                    read++;
                }

                chars[write++] = ch;

                if (count > 1)
                {
                    string countToString = count.ToString();
                    for(int i = 0; i < countToString.Length; i++)
                    {
                        chars[write++] = countToString[i];
                    }
                }
            }

            return write;
        }

        public static void MoveZeroes(int[] nums) {
            int write = 0;
            for (int read = 0; read < nums.Length; read ++)
            {
                if(nums[read] != 0)
                {
                    nums[write++] = nums[read];
                }

            } 

            while (write < nums.Length)
            {
                nums[write++] = 0;
            }
        }
    }
}