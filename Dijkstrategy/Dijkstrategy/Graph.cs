using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstrategy
{
    class Graph
    {
        Dictionary<string, Vertex> vertices;
        int[][] weights;

        int pathLength; //Current length, used for pathfinding
        List<Vertex> path; //Final path

        public Graph()
        {
            SetUpVertices();
            pathLength = 0;
            path = new List<Vertex>();
            path.Add(vertices["Hub"]);
        }

        public void Reset()
        {
            foreach (Vertex vertex in vertices.Values) vertex.completed = false;
            pathLength = 0;
            path = new List<Vertex>();
            path.Add(vertices["Hub"]);
        }

        public void ShortestPath()
        {
            Vertex nextVertex = path[0];
            while(nextVertex != null)
            {
                nextVertex = GetAdjacentUnvisited(path[path.Count - 1].Name);
                pathLength = pathLength + matrix[vertexIndices.IndexOf(path[path.Count - 1])][vertexIndices.IndexOf(nextVertex)];
            }
        }

        public Vertex GetAdjacentUnvisited(String name)
        {
            Vertex vertex = vertices[name];
            foreach(string neighbor in vertex.adjacencies)
            {

            }
            return null;
        }

        private void SetUpVertices()
        {
            vertices.Add("Hub", new Vertex("Hub", new List<string> { "Invisible", "Dragons' Sky", "Virtual", "Undead"}));
            vertices.Add("Invisible", new Vertex("Invisible", new List<string> { "Hub", "Dragon's Sky", "Virtual"}));
            vertices.Add("Dragons' Sky", new Vertex("Dragons' Sky", new List<string> { "Hub", "Invisible"}));
            vertices.Add("Virtual", new Vertex("Virtual", new List<string> { "Hub", "Undead", "Invisible", "???"}));
            vertices.Add("Undead", new Vertex("Undead", new List<string> { "Hub", "Virtual", "???"}));
            vertices.Add("???", new Vertex("???", new List<string> { "Virtual", "Undead"}));
            weights = new int[6][];
            weights[0] = new int[] { 3, 7, 2, 5};
            weights[1] = new int[] { 3, 3, 9};
            weights[2] = new int[] { 7, 3};
            weights[3] = new int[] { 2, 4, 9, 11};
            weights[4] = new int[] { 5, 4, 4};
            weights[5] = new int[] { 11, 4};
        }
    }
}
