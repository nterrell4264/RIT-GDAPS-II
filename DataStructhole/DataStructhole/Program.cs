using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructhole
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 14; i++) {
                PegPuzzle puzzle = new PegPuzzle(i);
                Thread thread = new Thread(new ThreadStart(puzzle.Solve));
                thread.Start();
            };
        }
    }
}
