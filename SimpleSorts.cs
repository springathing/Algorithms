using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class SimpleSorts
    {
        public void SelectionSort(int[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("Selection Sort");
            Console.WriteLine("--------------");

            Console.WriteLine();
            Console.WriteLine("Description: For each iteration the inner loop traverses array to find minimum value and swaps with the current position in the singly traversing outer loop");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            int min;
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                min = i;
                Console.WriteLine("Min Index: " + i.ToString());
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[min])
                    {
                        min = j;
                        Console.WriteLine("  New Min Index: " + j.ToString() + "; " + nums[j].ToString() + " < " + nums[i].ToString());
                    }
                }

                if (min != i)
                {
                    Console.WriteLine("    SWAP");
                    temp = nums[i];
                    nums[i] = nums[min];
                    nums[min] = temp;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            for (int after = 0; after < nums.Length; after++)
            {
                Console.Write(nums[after].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("--------------");
        }

        public void InsertionSort(int[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("Insertion Sort");
            Console.WriteLine("--------------");

            Console.WriteLine();
            Console.WriteLine("Description: For each position, a decrementing loop compares adjacent values from current position to index zero");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            for (int i = 1; i < nums.Length; i++)
            {
                Console.WriteLine("Outer Loop Index: " + i.ToString());
                for (int j = i - 1; j >= 0; j--)
                {
                    Console.WriteLine("  Comparing " + nums[j] + " and " + nums[j + 1]);
                    if (nums[j + 1] < nums[j])
                    {
                        Console.WriteLine("    SWAP");
                        int temp = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = temp;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            for (int after = 0; after < nums.Length; after++)
            {
                Console.Write(nums[after].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("--------------");
        }
    }
}
