using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegorithm
{
    class Peg
    {
        public bool empty;
        public int Index { get; private set; }
        public Dictionary<Peg, Peg> moves; //Key peg is the adjacent one, value peg is one after that.

        public Peg(int slot)
        {
            Index = slot;
            empty = false;
            moves = new Dictionary<Peg, Peg>();
        }

        public Peg KeyOf(Peg peg)
        {
            foreach (KeyValuePair<Peg, Peg> move in moves)
                if (move.Value.Equals(peg)) return move.Key;
            return null;
        }
    }
}
