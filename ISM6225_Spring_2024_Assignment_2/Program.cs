using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        // Edge case: if nums is null or empty, return empty list
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    return new List<int>(); // Placeholder
                
                // Mark visited numbers as negative
                for (int i=0; i<nums.Length; i++){
                    int index = Math.Abs(nums[i]) - 1; 
                    if (nums[index] > 0){
                        nums[index] = -nums[index]; 
                    }
                }
                // Any index that remains positive means the number (index + 1) is missing
                List<int> result = new List<int>();
                for (int i = 0; i < nums.Length; i++){
                    if (nums[i] > 0){
                        result.Add(i + 1);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        // Edge Case: Return empty array if input is null or empty
        public static int[] SortArrayByParity(int[] nums)
    {
    try
    {
        if (nums == null || nums.Length == 0)
            return new int[0];
        int n = nums.Length;
        int insertPos = 0;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] % 2 == 0)
            {
                int temp = nums[i];
                // Shift elements to the right
                for (int j = i; j > insertPos; j--)
                {
                    nums[j] = nums[j - 1];
                }
                nums[insertPos] = temp;
                insertPos++;
            }
        }

        return nums;
    }
    catch (Exception)
    {
        throw;
    }
}
        // Question 3: Two Sum
        // Edge Cases Handeled: No valid pair → returns empty array Multiple pairs → returns first valid pair
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Dictionary to store the number and its index
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }
                    // Add current number to map
                    if (!map.ContainsKey(nums[i])) // To handle duplicates properly
                    {
                        map[nums[i]] = i;
                    }
                }
                // If no solution is found
                return new int[0]; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Question 4: Find Maximum Product of Three Numbers
        // Edge Cases Handeled: Arrays with negative values/ Arrays where minimum values could lead to a larger positive product
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array

                int n = nums.Length;
                // Product of three largest numbers
                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

                // Product of two smallest and largest number
                int product2 = nums[0] * nums[1] * nums[n - 1];

                return Math.Max(product1, product2);
                // return 0; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        // Edge Cases: Return 0 if the decimal number is 0
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if(decimalNumber == 0)
                    return "0";
                
                // To Convert Decimal to Binary
                string binary = "";
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2 ) + binary;
                    decimalNumber = decimalNumber / 2;
                }
                return binary;
                // return "101010"; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int mid  = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        // The min is to the right of mid
                        left = mid + 1;
                    }
                    else
                    {
                        // The min is at mid or to the left of mid
                        right = mid;
                    }
                }
                return nums[left]; 
                // return 0; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Edges Cases if the number is less than 0
                if (x < 0 || (x % 10 == 0 && x != 0))
                    return false; 
                
                int reversed = 0;
                while (x > reversed)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit; 
                    x = x / 10;
                }
                // For odd-digit numbers, get rid of the middle digit using reversed / 10
                return x == reversed || x == reversed / 10;
                // return false; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Handle Base Cases
                if (n==0)
                    return 0;
                if (n==1)
                    return 1;
                
                int prev = 0;
                int current = 1;

                for (int i=2; i<=n; i++){
                    
                    int temp = current;
                    current = prev + current;
                    prev = temp;
                }
                return current; 
                // return 0; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
