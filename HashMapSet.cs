namespace MyApp
{
    static class HashMapSet
    {
        public static IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
            var set1 = new HashSet<int>(nums1);
            var set2 = new HashSet<int>(nums2);

            var dif1 = set1.Except(set2).ToList();
            var dif2 = set2.Except(set1).ToList();

            return new List<IList<int>> { dif1, dif2 };
        }

        public static bool UniqueOccurrences(int[] arr) {
            Dictionary<int, int> occurrences = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!occurrences.ContainsKey(arr[i])) occurrences[arr[i]] = 0;
                occurrences[arr[i]] ++;
            }

            var  keyList = occurrences.Keys.ToList();
            var valueList = new HashSet<int>(occurrences.Values.ToList());

            return keyList.Count == valueList.Count;
        }

        public static bool CloseString(string word1, string word2)
        {
            if(word1.Length != word2.Length) return false;

            var set1 = new HashSet<char> (word1);
            var set2 = new HashSet<char> (word2);
            var occurences1 = new Dictionary<char, int>();
            var occurences2 = new Dictionary<char, int>();

            foreach(char ch in word1)
            {
                if(!occurences1.ContainsKey(ch)) occurences1[ch] = 0;
                occurences1[ch] ++;
            }

            foreach(char ch in word2)
            {
                if(!occurences2.ContainsKey(ch)) occurences2[ch] = 0;
                occurences2[ch] ++;
            }

            List<int> frequencies1 = new List<int>(occurences1.Values);
            List<int> frequencies2 = new List<int>(occurences2.Values);

            frequencies1.Sort();
            frequencies2.Sort();
            
            return set1.SetEquals(set2) && frequencies1.SequenceEqual(frequencies2);
        }
    }
}