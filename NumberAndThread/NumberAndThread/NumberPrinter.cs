using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberAndThread
{
    class NumberPrinter
    {
        private int number;

        public NumberPrinter(int num)
        {
            number = num;
        }

        public void Print()
        {
            Console.ForegroundColor = (ConsoleColor)(number % 16);
            for (int i = 0; i < 50; i++) Console.Write(number + " ");
        }
    }
}
