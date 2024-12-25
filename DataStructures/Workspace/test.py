class Solution:
    def rangeSum(self, nums, n, left, right):
        MOD = 10**9 + 7
        
        # Step 1: Compute prefix sums
        prefix_sums = [0] * (n + 1)
        for i in range(n):
            prefix_sums[i + 1] = prefix_sums[i] + nums[i]
        print("prefix_sums",prefix_sums)
        # Step 2: Generate all subarray sums
        subarray_sums = []
        for i in range(n):
            for j in range(i + 1, n + 1):
                aa=nums[i:j]
                print("SubArray",aa)
                aaa=prefix_sums[j] - prefix_sums[i]
                print("SubArray sum",aaa)
                subarray_sums.append(prefix_sums[j] - prefix_sums[i])
        
        # Step 3: Sort the subarray sums
        subarray_sums.sort()
        
        # Step 4: Compute the sum from index left to right
        result = 0
        for i in range(left - 1, right):
            result = (result + subarray_sums[i]) % MOD
        
        return result

# Example usage
sol = Solution()
nums = [1, 2, 3, 4]
n = 4
left = 1
right = 5
print(sol.rangeSum(nums, n, left, right))  # Output: 13


