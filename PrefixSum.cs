namespace MyApp
{
    static class PrefixSum
    {
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