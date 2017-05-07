using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructhole
{
    class PegPuzzle
    {
        private List<Peg> pegs;
        public Stack<Tuple<Peg, Peg>> solution { get; private set; }
        private List<Peg> empties;
        private static object consoleLock;

        static PegPuzzle()
        {
            consoleLock = new object();
        }
        public PegPuzzle(int startEmpty)
        {
            pegs = CreatePuzzle();
            solution = new Stack<Tuple<Peg, Peg>>();
            empties = new List<Peg>();
            empties.Add(pegs[startEmpty]);
            empties[0].empty = true;
        }

        public void Solve()
        {
            this.SolvePuzzle();
        }

        private bool SolvePuzzle()
        {
            if(solution.Count == 13)
            {
                lock (consoleLock)
                {
                    List<Tuple<Peg, Peg>> order = solution.ToList();
                    for (int i = order.Count - 1; i >= 0; i--)
                    {
                        Console.WriteLine("{0} to {1}", order[i].Item1.Index, order[i].Item2.Index);
                    }
                    Console.WriteLine("=========");
                }
                return true;
            }
            else
            {
                //foreach (Peg emptyPeg in empties)
                for(int i = 0; i < empties.Count; i++)
                    foreach(Peg adjacent in empties[i].moves.Keys)
                        if (ValidMove(adjacent, empties[i]))
                        {
                            PerformMove(adjacent, empties[i]);
                            if(SolvePuzzle()) return true;
                        }
                //This code is called after recursion - meaning a valid solution was not found down this path
                if (solution.Count > 1)
                {
                    Tuple<Peg, Peg> removed = solution.Pop();
                    PerformMove(removed.Item1, removed.Item2, true);
                }
                return false;
            }
        }

        /// <summary>
        /// Simulates a peg jump by changing the appropriate properties. Can also undo a move.
        /// </summary>
        /// <param name="source">The jumping peg</param>
        /// <param name="target">The peg to be jumped to</param>
        /// <param name="reverse">False by default; setting to true makes the move a takeback. </param>
        private void PerformMove(Peg source, Peg target, bool reverse = false)
        {
            source.empty = !reverse;
            source.moves[target].empty = !reverse;
            target.empty = reverse;
            if (!reverse)
            {
                empties.Add(source);
                empties.Add(source.moves[target]);
                empties.Remove(target);
                solution.Push(new Tuple<Peg, Peg>(source, target));
            }
            else
            {
                empties.Remove(source);
                empties.Remove(source.moves[target]);
                empties.Add(target);
            }
        }

        private bool ValidMove(Peg source, Peg target)
        {
            return !source.empty && source.moves.ContainsKey(target) && !source.moves[target].empty && target.empty;
        }

        public static List<Peg> CreatePuzzle()
        {
            List<Peg> result = new List<Peg>();
            result.Add(new Peg(0));
            result.Add(new Peg(1));
            result.Add(new Peg(2));
            result.Add(new Peg(3));
            result.Add(new Peg(4));
            result.Add(new Peg(5));
            result.Add(new Peg(6));
            result.Add(new Peg(7));
            result.Add(new Peg(8));
            result.Add(new Peg(9));
            result.Add(new Peg(10));
            result.Add(new Peg(11));
            result.Add(new Peg(12));
            result.Add(new Peg(13));
            result.Add(new Peg(14));

            result[0].moves = new Dictionary<Peg, Peg>();
            result[0].moves.Add(result[3], result[1]);
            result[0].moves.Add(result[5], result[2]);

            result[1].moves = new Dictionary<Peg, Peg>();
            result[1].moves.Add(result[6], result[3]);
            result[1].moves.Add(result[8], result[4]);

            result[2].moves = new Dictionary<Peg, Peg>();
            result[2].moves.Add(result[7], result[4]);
            result[2].moves.Add(result[9], result[5]);

            result[3].moves = new Dictionary<Peg, Peg>();
            result[3].moves.Add(result[0], result[1]);
            result[3].moves.Add(result[5], result[4]);
            result[3].moves.Add(result[10], result[6]);
            result[3].moves.Add(result[12], result[7]);

            result[4].moves = new Dictionary<Peg, Peg>();
            result[4].moves.Add(result[11], result[7]);
            result[4].moves.Add(result[13], result[8]);

            result[5].moves = new Dictionary<Peg, Peg>();
            result[5].moves.Add(result[0], result[2]);
            result[5].moves.Add(result[3], result[4]);
            result[5].moves.Add(result[12], result[8]);
            result[5].moves.Add(result[14], result[9]);

            result[6].moves = new Dictionary<Peg, Peg>();
            result[6].moves.Add(result[1], result[3]);
            result[6].moves.Add(result[8], result[7]);

            result[7].moves = new Dictionary<Peg, Peg>();
            result[7].moves.Add(result[2], result[4]);
            result[7].moves.Add(result[9], result[8]);

            result[8].moves = new Dictionary<Peg, Peg>();
            result[8].moves.Add(result[1], result[4]);
            result[8].moves.Add(result[6], result[7]);

            result[9].moves = new Dictionary<Peg, Peg>();
            result[9].moves.Add(result[2], result[5]);
            result[9].moves.Add(result[7], result[8]);

            result[10].moves = new Dictionary<Peg, Peg>();
            result[10].moves.Add(result[3], result[6]);
            result[10].moves.Add(result[12], result[11]);

            result[11].moves = new Dictionary<Peg, Peg>();
            result[11].moves.Add(result[4], result[7]);
            result[11].moves.Add(result[13], result[12]);

            result[12].moves = new Dictionary<Peg, Peg>();
            result[12].moves.Add(result[3], result[7]);
            result[12].moves.Add(result[5], result[8]);
            result[12].moves.Add(result[10], result[11]);
            result[12].moves.Add(result[14], result[13]);

            result[13].moves = new Dictionary<Peg, Peg>();
            result[13].moves.Add(result[4], result[8]);
            result[13].moves.Add(result[11], result[12]);

            result[14].moves = new Dictionary<Peg, Peg>();
            result[14].moves.Add(result[5], result[9]);
            result[14].moves.Add(result[12], result[13]);

            return result;
        }
    }
}
