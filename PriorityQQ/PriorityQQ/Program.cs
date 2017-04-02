using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQQ
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Enqueue(5);
            queue.Enqueue(17);
            queue.Enqueue(900);
            queue.Enqueue(45);
            queue.Enqueue(86);
            queue.Enqueue(19);
            queue.Enqueue(127);
            queue.Enqueue(4);
            queue.Enqueue(602);
            queue.Enqueue(0);
            int times = queue.Count;
            for (int i = 0; i < times; i++) Console.WriteLine(queue.Dequeue());
        }
    }
}
