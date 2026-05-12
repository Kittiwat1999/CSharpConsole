namespace MyApp
{
    static class SlidingWindow
    {
        public static double FindMaxAverage(int[] nums, int k) {
            double avg = 0;
            double sum = 0;
            int left = 0;
            int right =  k - 1;
            for (int i = 0; i < k ; i++) {
                sum += nums[i];
            }

            avg = sum / k;

            while (right < nums.Length - 1) {
                sum += nums[++right];
                sum -= nums[left++];

                avg = Math.Max(avg, sum / k);

            }

            return avg;
        }

        public static int MaxVowels(string s, int k) {
            string wovels = "aeiou";
            int max;
            int count = 0;
            int left = 0;
            int right = k-1;

            for (int i = 0; i < k; i++) {
                if (wovels.Contains(s[i])) {
                    count ++;
                }
            }

            max = count;

            while (right < s.Length - 1) {
                if (wovels.Contains(s[++right])) {
                    count ++;
                }
                if (wovels.Contains(s[left ++])) {
                    count --;
                }

                max = Math.Max(max, count);
            }

            return max;
        }
    }
}