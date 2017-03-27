using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 0, -1, 100, -50, 6 };

            MergeSortSolver.MergeSort(array, 0, array.Length-1);

            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
