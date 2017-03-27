using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(200);


            Console.WriteLine(queue.Count);
            Console.ReadKey();
        }
    }
}
