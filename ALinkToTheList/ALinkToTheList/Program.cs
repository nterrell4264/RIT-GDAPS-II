using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALinkToTheList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> nums = new LinkedList<int>();
            nums.Add(42);
            nums.Add(64);
            nums.Add(123);
            nums.Add(9001);
            nums.Add(0);

            Console.WriteLine(nums.ToString());

            LinkedList<float> flots = new LinkedList<float>();
            flots.Add(42);
            flots.Add(64);

            Console.WriteLine(flots.ToString());
        }
    }
}
