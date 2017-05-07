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
            List<PegPuzzle> puzzles = new List<PegPuzzle>();
            for (int i = 0; i < 14; i++)
            {
                puzzles.Add(new PegPuzzle(i));
                Thread thread = new Thread(new ThreadStart(puzzles[i].SolvePuzzle));
                thread.Start();
            };
            foreach(PegPuzzle puzzle in puzzles)
            {
                lock ()
                {
                    txtResult.Text += puzzle.SolutionString();
                }
            }
        }
    }
}
