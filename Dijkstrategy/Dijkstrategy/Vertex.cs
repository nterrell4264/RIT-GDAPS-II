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
        public bool completed; //Whether the vertex's inclusion/exclusion is finalized

        //Constructor
        public Vertex(string name)
        {
            Name = name;
            completed = false;
        }
    }
}
