using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pegorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Tuple<PegPuzzle, Thread>> puzzles = new List<Tuple<PegPuzzle, Thread>>();
            for (int i = 0; i < 15; i++)
            {
                PegPuzzle puzzle = new PegPuzzle(i);
                Thread thread = new Thread(new ThreadStart(puzzle.Solve));
                thread.Start();
                puzzles.Add(new Tuple<PegPuzzle, Thread>(puzzle, thread));
            };
            foreach(Tuple<PegPuzzle, Thread> puzzle in puzzles)
            {
                puzzle.Item2.Join();
                lock (PegPuzzle.consoleLock)
                {
                    txtResult.Text += puzzle.Item1.SolutionString();
                }
            }
        }
    }
}
