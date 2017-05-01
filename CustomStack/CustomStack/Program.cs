using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
	class Program
	{
		static void Main(string[] args)
		{
            GameStack moves = new GameStack();
            moves.Push("e4");
            moves.Push("e5");
            moves.Push("d4");
            moves.Push("Nc6");
            moves.Push("Nf3");
            moves.Push("Nf6");
            moves.Push("Nc3");
            moves.Push("Bd6");
            moves.Push("h4");
            moves.Push("0-0");

            int times = moves.Count;
            for (int i = 0; i < times; i++) Console.WriteLine(moves.Pop());
        }
	}
}
