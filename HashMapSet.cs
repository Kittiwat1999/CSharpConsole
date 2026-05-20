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
    }
}