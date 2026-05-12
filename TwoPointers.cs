namespace MyApp
{
    static class TwoPointers
    {
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

        public static bool IsSubsequence(string s, string t) {
            int read_s = 0;
            int read_t = 0;

            if (s.Length == 0) return true;
            if (t.Length == 0) return false;

            while (read_t < t.Length) {
                if (t[read_t] == s[read_s]) {
                    read_s ++;
                    if (read_s == s.Length) return true;
                }

                read_t ++;
            }

            return false;
        }

        public static int MaxArea(int[] height) {
            int maxArea = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                int minHeight = Math.Min(height[left], height[right]);
                maxArea = Math.Max(minHeight * (right - left), maxArea);
                if (height[left] > height[right])
                {
                    right --;
                } else {
                    left ++;
                }
            }

            return maxArea;
        }

        public static int MaxOperations(int[] nums, int k) {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int operations = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = k - nums[i];
                if (dict.ContainsKey(complement) && dict[complement] > 0)
                {
                    operations++;
                    dict[complement]--;
                }
                else
                {
                    if (!dict.ContainsKey(nums[i]))
                    {
                        dict[nums[i]] = 0;
                    }
                    dict[nums[i]]++;
                }
            }

            return operations;
        }
    }
}