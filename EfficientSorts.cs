using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class EfficientSorts
    {
        public void QuickSort(int[] nums, int left, int right)
        {
            Console.WriteLine();
            Console.WriteLine("Quick Sort");
            Console.WriteLine("----------");

            Console.WriteLine();
            Console.WriteLine("Description: A divide and conquer algorithm that sorts the input array inplace using smaller index ranges and pivots");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            QuickSortHelper(ref nums, left, right);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            for (int after = 0; after < nums.Length; after++)
            {
                Console.Write(nums[after].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("----------");
        }

        private void QuickSortHelper(ref int[] nums, int left, int right)
        {
            Console.WriteLine();
            Console.WriteLine();
            int leftEnd = left;
            int rightEnd = right;
            int pivot = nums[left];
            Console.WriteLine("Pivot is leftmost item: " + pivot.ToString());
            while (left < right)
            {
                while ((nums[right] >= pivot) && (left < right)) // Decrement right until find number that isn't bigger than pivot value
                {
                    Console.WriteLine("  Right Value > Pivot, Decrement");
                    right--;
                }

                if (left != right) // replace left most value with right most value
                {
                    Console.WriteLine("    Smaller Value Found, SWAP");
                    Console.WriteLine("    " + nums[left].ToString() + " is replaced by " + nums[right].ToString());
                    nums[left] = nums[right];
                    left++;
                }

                while ((nums[left] <= pivot) && (left < right)) // increment left until find number that isn't smaller than pivot value
                {
                    Console.WriteLine("  Left Value < Pivot, Increment");
                    left++;
                }

                if (left != right) // replace right most value with left most value
                {
                    Console.WriteLine("    Larger Value Found, SWAP");
                    Console.WriteLine("    " + nums[right].ToString() + " is replaced by " + nums[left].ToString());
                    nums[right] = nums[left];
                    right--;
                }
            }

            Console.WriteLine("    " + nums[left] + " is replaced by original pivot: " + pivot.ToString());
            nums[left] = pivot; // replace last value with originally left most pivot value
            Console.WriteLine("        Successful Rearrangement around Pivot, left/right reset");
            pivot = left; // pivot is equal to what left and right indexes are equal to
            left = leftEnd; // left is reset to original left most index
            right = rightEnd; // right is reset to original right most index
            
            if (left < pivot && pivot - left > 1) // recursive call for index 0 up to but no including pivot index
            {
                Console.WriteLine("        Recursive call for left side of pivot made");
                QuickSortHelper(ref nums, left, pivot - 1);
            }
           
            if (right > pivot && right - pivot > 1)  // recursive call for pivot index + 1 up to the end of the input array
            {
                Console.WriteLine("        Recursive call for right side of pivot made");
                QuickSortHelper(ref nums, pivot + 1, right);
            }
        }

        public void MergeSort(int[] nums, int left, int right)
        {
            Console.WriteLine();
            Console.WriteLine("Merge Sort");
            Console.WriteLine("----------");

            Console.WriteLine();
            Console.WriteLine("Description: A divide-and-conquer algorithm that sorts the input array using subarrays");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            MergeSortSortMerge(ref nums, left, right);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            for (int after = 0; after < nums.Length; after++)
            {
                Console.Write(nums[after].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("----------");
        }

        private void MergeSortSortMerge(ref int[] nums, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                Console.WriteLine("Recursive call for left half");
                MergeSortSortMerge(ref nums, left, mid);
                Console.WriteLine("Recursive call for right half");
                MergeSortSortMerge(ref nums, mid + 1, right);
                Console.WriteLine("  Merging call of two halves");
                MergeSortMainMerge(ref nums, left, mid + 1, right);
            }
        }

        private void MergeSortMainMerge(ref int[] nums, int left, int mid, int right)
        {
            int[] tempArr = new int[nums.Length];
            int leftend;
            int numElements;
            int tempPosition;

            leftend = mid - 1;
            tempPosition = left;
            numElements = right - left + 1;

            while ((left <= leftend) && (mid <= right)) // while left approaches middle, and one after middle approaches right end
            {
                Console.WriteLine("    Comparing and inserting: " + nums[left].ToString() + " & " + nums[mid].ToString());
                if (nums[left] <= nums[mid])  // if left number is smaller than right number
                {
                    tempArr[tempPosition++] = nums[left++];
                }
                else
                {
                    tempArr[tempPosition++] = nums[mid++];
                }
            }

            while (left <= leftend) // any remaining elements on left side inputted into temp array
            {
                Console.WriteLine("      Adding remaining element: " + nums[left].ToString());
                tempArr[tempPosition++] = nums[left++];
            }

            while (mid <= right) // any remaining elements on right side inputted into temp array
            {
                Console.WriteLine("      Adding remaining element: " + nums[mid].ToString());
                tempArr[tempPosition++] = nums[mid++];
            }

            for (int i = 0; i < numElements; i++) // updated nums array for tempArr range of values
            {
                Console.WriteLine("        Elements updated to original array");
                nums[right] = tempArr[right];
                right--;
            }
        }

        public void HeapSort(int[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("Heap Sort");
            Console.WriteLine("---------");

            Console.WriteLine();
            Console.WriteLine("Description: Sorting done by a tree data structure where the largest/smallest element is placed at end of array");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            // Build-Max-Heap from input array
            int heapSize = nums.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
            {
                Console.WriteLine("Building Heap: Step " + p.ToString());
                MaxHeapify(ref nums, heapSize, p);
            }

            // Sort heap from last element, decrease heapSize every time largest element found and swap to put at end
            Console.WriteLine("  Beginning to sort");
            for (int i = nums.Length - 1; i > 0; i--)
            {
                Console.WriteLine("  Flipping " + nums[i].ToString() + " at index " + i.ToString() + ", with " + nums[0].ToString() + " at index 0");
                int temp = nums[i];
                nums[i] = nums[0];
                nums[0] = temp;
                Console.WriteLine("  Decreasing heapsize to " + (heapSize - 1).ToString());
                heapSize--;
                Console.WriteLine("  Reheapifying");
                MaxHeapify(ref nums, heapSize, 0);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            for (int after = 0; after < nums.Length; after++)
            {
                Console.Write(nums[after].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("---------");
        }

        private void MaxHeapify(ref int[] nums, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1; // left index past 0th index to check
            int right = (index + 1) * 2; // right index past 0th index to check
            Console.WriteLine("    Left index: " + left.ToString() + "; Right index: " + right.ToString());
            int largest = 0;

            if (left < heapSize && nums[left] > nums[index])
            {
                Console.WriteLine("    Value at left index " + left.ToString() + " is larger than at index " + largest.ToString());
                largest = left;
            }
            else
            {
                largest = index;
                Console.WriteLine("    Left index isn't larger, largest still at index: " + largest.ToString());
            }

            if (right < heapSize && nums[right] > nums[largest])
            {
                Console.WriteLine("    Value at right index " + right.ToString() + " is larger than at index " + largest.ToString());
                largest = right;
            }

            if (largest != index) // if largest index isn't equal to index, swap to put greater value at top of heap
            {
                Console.WriteLine("      SWAP: " + nums[largest].ToString() + " bigger than " + nums[index].ToString());
                int temp = nums[index];
                nums[index] = nums[largest];
                nums[largest] = temp;
                Console.WriteLine("      Re-heapify");
                MaxHeapify(ref nums, heapSize, largest);
            }
        }
    }
}
