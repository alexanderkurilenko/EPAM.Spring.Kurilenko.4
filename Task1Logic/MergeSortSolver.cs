using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public static class MergeSortSolver
    {
        #region Methods
        /// <summary>
        /// Merge sort  recursive function
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void MergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
           
        }

        /// <summary>
        /// Merging of array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="middle"></param>
        /// <param name="high"></param>
        public static void Merge(int[] array, int low, int middle, int high)
        {
            int[] helper = new int[array.Length];

            for (int i = low; i <= high; i++)
            {
                helper[i] = array[i];
            }

            int helperLeft = low;
            int helperRight = middle + 1;
            int current = low;

            while (helperLeft <= middle && helperRight <= high)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    array[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    array[current] = helper[helperRight];
                    helperRight++;
                }
                current++;
            }

            int remaining = middle - helperLeft;
            
            for (int i = 0; i <= remaining; i++)
            {
                array[current + i] = helper[helperLeft + i];
            }
        }
    }
        #endregion
}
