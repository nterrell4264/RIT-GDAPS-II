using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberAndThread
{
    class GamePlay
    {
        private String task;

        public GamePlay(String assignment)
        {
            task = assignment;
        }

        public void Update()
        {
            for (int i = 1; i <= 10; i++) Console.WriteLine(task + ": " + i * 10 + "%");
        }
    }
}
