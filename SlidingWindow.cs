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
                if (max == k) break;
            }

            return max;
        }

        public static int LongestOnes(int[] nums, int k) {
            int max = 0;
            int zero_count = 0;
            int left = 0;
            
            for (int right = 0; right < nums.Length; right++) {
               if (nums[right] == 0) {
                    zero_count ++;
                }

                while (zero_count > k) {
                    if (nums[left++] == 0) {
                        zero_count --;
                    }
                }

                max = Math.Max(max, right - left + 1);
            }
            return max;
        }

        public static int LongestSubarray(int[] nums) {
            int max = 0;
            int zero_count = 0;
            int left = 0;
            
            for (int right = 0; right < nums.Length; right++) {
               if (nums[right] == 0) {
                    zero_count ++;
                }

                while (zero_count > 1) {
                    if (nums[left++] == 0) {
                        zero_count --;
                    }
                }

                max = Math.Max(max, right - left);
            }
            return max;
        }

        public static int PivotIndex(int[] nums) {
            int rightSum = 0;
            int leftSum = 0;
            for (int i = 0; i<nums.Length; i++) 
            {
                rightSum += nums[i];
            }

            for (int j = 0; j<nums.Length; j++) 
            {
                rightSum -= nums[j];
                if(rightSum == leftSum) return j;
                leftSum += nums[j];
            }
            return -1;
        }
    }
}