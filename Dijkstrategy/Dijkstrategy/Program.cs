using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ShortestPath("???");
            string input;
            string room1 = "";
            string room2 = "";
            List<Vertex> path1;
            List<Vertex> path2;
            bool finished = false;
                Console.WriteLine("Welcome to the Extravagant Zoo Router. This module creates routes for you.");
            while (!finished)
            {
                Console.WriteLine("Type in where you are and where you want to go.");
                input = Console.ReadLine();
                if (input.Equals("done")) finished = true;
                foreach(string room in graph.vertices.Keys)
                {
                    if (input.Equals(room))
                    {
                        room1 = input;
                        break;
                    }
                }
                if (!room1.Equals(""))
                {
                    input = Console.ReadLine();
                    foreach (string room in graph.vertices.Keys)
                    {
                        if (input.Equals(room))
                        {
                            room2 = input;
                            break;
                        }
                    }
                    if(room2.Equals("")) Console.WriteLine("That is not a valid room in the zoo.");
                    else
                    {
                        while(room1)
                    }
                }
                else Console.WriteLine("That is not a valid room in the zoo.");
            }
        }
    }
}
