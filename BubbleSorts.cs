using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class BubbleSorts
    {
        public void BubbleSort(int[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("Bubble Sort");
            Console.WriteLine("-----------");

            Console.WriteLine();
            Console.WriteLine("Description: Adjacent items are swapped in each iteration for as many iterations as there are items in the array");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - 1; j++)
                {
                    Console.WriteLine("First: " + nums[j].ToString() + "; Second: " + nums[j + 1].ToString());
                    if (nums[j] > nums[j + 1])
                    {
                        Console.WriteLine("  SWAP");
                        temp = nums[j + 1];
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
            Console.WriteLine("-----------");
        }

        public void ShellSort(int[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("Shell Sort");
            Console.WriteLine("----------");

            Console.WriteLine();
            Console.WriteLine("Description: Insertion/bubble sort generalization, which starts by comparing elements that are far apart and gradually reduces the gap between elements being compared.");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            int length = nums.Length;
            int gap = length / 2;
            int temp;
            while (gap > 0)
            {
                Console.WriteLine("Current gap: " + gap.ToString());
                for (int i = 0; i + gap < length; i++)
                {
                    Console.WriteLine("  Current Index: " + i.ToString() + "; Value: " + nums[i].ToString());
                    int j = i + gap; // digit at the end of current gap
                    temp = nums[j];
                    Console.WriteLine("    Comparison Index: " + j.ToString() + "; Comparison Value: " + temp.ToString());
                    while (j - gap >= 0 && temp < nums[j - gap]) // subtract gap sizes from j until it hits <= 0 and to put end in lowest 
                    {
                        Console.WriteLine("      SWAP");
                        nums[j] = nums[j - gap];
                        j = j - gap;
                        Console.WriteLine("        Next Comparison Index: " + j.ToString());
                    }
                    nums[j] = temp;
                }
                gap = gap / 2;
            }

            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            for (int after = 0; after < nums.Length; after++)
            {
                Console.Write(nums[after].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("----------");
        }

        public void CombSort(int[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("Comb Sort");
            Console.WriteLine("---------");

            Console.WriteLine();
            Console.WriteLine("Description: Improvement on bubble sort performance to catch small values at end by increasing gap of comparison");

            Console.WriteLine();
            Console.WriteLine("Unsorted Array:");
            for (int before = 0; before < nums.Length; before++)
            {
                Console.Write(nums[before].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            double gap = nums.Length;
            bool swaps = true;

            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;
                 if (gap < 1)
                 {
                     gap = 1;
                 }
                 Console.WriteLine("Current gap: " + gap.ToString());

                 int i = 0;
                 swaps = false;

                while (i + gap < nums.Length)
                {
                    int igap = i + (int)gap;
                    if (nums[i] > nums[igap])
                    {
                        int temp = nums[i];
                        nums[i] = nums[igap];
                        nums[igap] = temp;
                        swaps = true;
                        Console.WriteLine("  Index: " + i.ToString() + "; Comparison Index: " + igap.ToString());
                        Console.WriteLine("    SWAP");
                    }

                    i++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            for (int after = 0; after < nums.Length; after++)
            {
                Console.Write(nums[after].ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine("---------");
        }
    }
}
