using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstrategy
{
    class Vertex
    {
        public string Name { get; private set; }
        public List<string> adjacencies;

        public bool completed; //Whether the vertex's inclusion/exclusion is finalized
        public Vertex nearestNeighbor;
        public int distance; //distance from source node

        //Constructor
        public Vertex(string name, List<string> neighbors)
        {
            Name = name;
            adjacencies = neighbors;
            completed = false;
        }
    }
}
