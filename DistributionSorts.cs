using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class DistributionSorts
    {
        public void CountingSort(int[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("Counting Sort");
            Console.WriteLine("-------------");

            Console.WriteLine();
            Console.WriteLine("Description: Sorts based on keys between a specific range. Calculates the sorted index per object based on the number of distinct objects.");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            int[] sortedArr = new int[nums.Length];
            int min = nums[0];
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < min)
                {
                    min = nums[i];
                }
                else if (nums[i] > max)
                {
                    max = nums[i];
                }
            }
            int[] counts = new int[max - min + 1];
            Console.WriteLine("Max Value: " + max.ToString() + "; Min Value: " + min.ToString());

            for (int j = 0; j < nums.Length; j++)
            {
                counts[nums[j] - min]++;
            }
            Console.WriteLine("  Counting array values incremented based on input array occurences");

            counts[0]--;
            for (int k = 1; k < counts.Length; k++)
            {
                counts[k] = counts[k] + counts[k - 1];
            }
            Console.WriteLine("    Counting array values added up");

            for (int l = nums.Length - 1; l >= 0; l--)
            {
                sortedArr[counts[nums[l] - min]--] = nums[l];
                Console.WriteLine("      " + nums[l].ToString() + " was placed at index " + (counts[nums[l] - min] + 1).ToString());
            }

            for (int m = 0; m < sortedArr.Length; m++)
            {
                nums[m] = sortedArr[m];
            }
            Console.WriteLine("        Items transfered to original array");

            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            for (int after = 0; after < nums.Length; after++)
            {
                Console.Write(nums[after].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("--------------");
        }

        public void BucketSort(int[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("Bucket Sort");
            Console.WriteLine("-----------");

            Console.WriteLine();
            Console.WriteLine("Description: Works by partitioning an array into a number of buckets, and then each bucket is sorted individually with another sort or recursively");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            List<int> result = new List<int>();
            //Determine how many buckets you want to create, in this case, the 10 buckets will each contain a range of 10
            //1-10, 11-20, 21-30, etc. since the passed array is between 1 and 99
            Console.WriteLine("Number of buckets determined based on range of input values");
            int numOfBuckets = 10;
            //Create buckets
            List<int>[] buckets = new List<int>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<int>();
                Console.WriteLine("  Bucket number " + (i + 1).ToString() + " created");
            }

            //Iterate through the passed array and add each integer to the appropriate bucket
            for (int i = 0; i < nums.Length; i++)
            {
                int bucketChoice = (nums[i] / numOfBuckets);
                buckets[bucketChoice].Add(nums[i]);
            }
            Console.WriteLine("Each input value's destination bucket determined by the value divided by the number of buckets");

            //Sort each bucket and add it to the result List
            //Each sublist is sorted using Bubblesort, but you could substitute any sorting algo you would like
            for (int i = 0; i < numOfBuckets; i++)
            {
                int[] temp = BucketSortBubbleSortList(buckets[i]);
                result.AddRange(temp);
            }
            Console.WriteLine("Each bucket separately sorted by another sort (bubble sort in this instance) and joined back together");
            nums = result.ToArray();

            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            for (int after = 0; after < nums.Length; after++)
            {
                Console.Write(nums[after].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("--------------");
        }

        //Bubblesort w/ ListInput
        private static int[] BucketSortBubbleSortList(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if (input[i] < input[j])
                    {
                        int temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }
            return input.ToArray();
        }

        public void RadixSort(int[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("Radix Sort");
            Console.WriteLine("----------");

            Console.WriteLine();
            Console.WriteLine("Description: a non-comparative integer sorting algorithm that sorts data with integer keys by grouping keys by the individual digits which share the same significant position and value");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            // our helper array 
            int[] helper = new int[nums.Length];
            Console.WriteLine("Helper array created");

            // number of bits our group will be long 
            int r = 4; // try to set this also to 2, 8 or 16 to see if it is quicker or not 
            Console.WriteLine("Number of bits set to: " + r.ToString());

            // number of bits of a C# int 
            int b = 32;
            Console.WriteLine("Number of bits of a C# int: " + b.ToString());

            // counting and prefix arrays
            // (note dimensions 2^r which is the number of all possible values of a r-bit number) 
            int[] count = new int[1 << r];
            int[] pref = new int[1 << r];
            Console.WriteLine("Count and Prefix arrays created of size: " + (1 << r).ToString());

            // number of groups 
            int groups = (int)Math.Ceiling(b / (double)r);
            Console.WriteLine("Number of groups: " + groups.ToString());

            // the mask to identify groups 
            int mask = (1 << r) - 1;
            Console.WriteLine("Mask to identify groups created: " + ((1 << r) - 1).ToString());

            // the algorithm: 
            for (int c = 0, shift = 0; c < groups; c++, shift += r)
            {
                Console.WriteLine("  c (group number) value: " + c.ToString());
                Console.WriteLine("  shift value: " + shift.ToString());

                // reset count array 
                for (int j = 0; j < count.Length; j++)
                {
                    count[j] = 0;
                }
                Console.WriteLine("    Count array reset");

                Console.WriteLine("    Counting elements of the c-th group");
                // counting elements of the c-th group 
                for (int i = 0; i < nums.Length; i++)
                {
                    Console.WriteLine("      (nums[" + i.ToString() + "] >> shift) & mask: " + ((nums[i] >> shift) & mask).ToString());
                    count[(nums[i] >> shift) & mask]++;
                    Console.WriteLine("      " + (count[(nums[i] >> shift) & mask]).ToString());
                }

                Console.WriteLine("    Calculating prefixes");
                // calculating prefixes 
                pref[0] = 0;
                for (int i = 1; i < count.Length; i++)
                {
                    Console.WriteLine("      pref[i - 1]: " + pref[i - 1].ToString());
                    Console.WriteLine("      count[i - 1]: " + count[i - 1].ToString());
                    pref[i] = pref[i - 1] + count[i - 1];
                    Console.WriteLine("      pref[i]: " + pref[i].ToString());
                }

                Console.WriteLine("    Copying elements from original array to helper array ordered by c-th group");
                // from a[] to t[] elements ordered by c-th group 
                for (int i = 0; i < nums.Length; i++)
                {
                    helper[pref[(nums[i] >> shift) & mask]++] = nums[i];
                }

                Console.WriteLine("    Copying elements back into original array from helper array");
                // a[]=t[] and start again until the last group 
                helper.CopyTo(nums, 0);
            }
            // a is sorted 

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


// Alternate Radix Sort solution
//int i, j;
//int[] tmp = new int[nums.Length];
//            for (int shift = 31; shift > -1; --shift)
//            {
//                Console.WriteLine("Shift: " + shift.ToString());
//                j = 0;
//                Console.WriteLine("Value of J: " + j.ToString());
//                for (i = 0; i<nums.Length; ++i)
//                {
//                    bool move = (nums[i] << shift) >= 0;
//Console.WriteLine("  Move? " + move.ToString());
//                    Console.WriteLine("  Number being shifted: " + nums[i].ToString());
//                    Console.WriteLine("  Shift result: " + (nums[i] << shift).ToString());
//                    if (shift == 0 ? !move : move)
//                    {
//                        Console.WriteLine("    Shift > 0");
//                        Console.WriteLine("    Item being moved: " + nums[i].ToString());
//                        Console.WriteLine("    Index being updated: " + (i - j).ToString());
//                        Console.WriteLine("    Item currently at index: " + nums[i - j].ToString());
//                        nums[i - j] = nums[i];
//                    }
//                    else
//                    {
//                        Console.WriteLine("    Shift = 0");
//                        Console.WriteLine("    Temp j index value: " + tmp[j].ToString());
//                        Console.WriteLine("    Item being moved: " + nums[i].ToString());
//                        tmp[j++] = nums[i];
//                    }
//                }
//                Console.WriteLine("      Temp array being copied: ");
//                Array.Copy(tmp, 0, nums, nums.Length-j, j);
//                foreach (int item in tmp)
//                {
//                    Console.WriteLine("      Item: " + item.ToString());
//                }
//                Console.WriteLine();
//            } 