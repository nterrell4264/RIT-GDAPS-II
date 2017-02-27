using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberAndThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();

            for (int i = 0; i < 50; i++)
            {
                NumberPrinter colors = new NumberPrinter(rng.Next(1,16));
                //colors.Print();
                Thread t0 = new Thread(colors.Print);
                t0.Start();
            }

            Console.Clear();

            GamePlay aspect1 = new GamePlay("Reconfiguring Splines");
            GamePlay aspect2 = new GamePlay("Adapting Torsion");
            GamePlay aspect3 = new GamePlay("Doctoring Digestion Simulation");
            GamePlay aspect4 = new GamePlay("Performing Denomination Tests");
            GamePlay aspect5 = new GamePlay("Polishing Particulate Matter");
            List<Thread> threads = new List<Thread> { new Thread(aspect1.Update), new Thread(aspect2.Update), new Thread(aspect3.Update), new Thread(aspect4.Update), new Thread(aspect5.Update)};
            foreach (Thread task in threads) task.Start();
            foreach (Thread task in threads) task.Join();
            Console.WriteLine("Update Complete! Beginning Final Microtransactions");
        }
    }
}
