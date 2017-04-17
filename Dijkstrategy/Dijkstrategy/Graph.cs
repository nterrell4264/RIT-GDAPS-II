using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstrategy
{
    class Graph
    {
        public Dictionary<string, Vertex> vertices;
        List<string> vertexIndices;
        int[][] weights;

        public Graph()
        {
            SetUpVertices();
        }

        public void Reset()
        {
            foreach (Vertex vertex in vertices.Values)
            {
                vertex.completed = false;
                vertex.nearestNeighbor = null;
                vertex.distance = int.MaxValue;
            }
        }

        public void ShortestPath(string start)
        {
            Stack<Vertex> currentPath = new Stack<Vertex>();
            Vertex currentVertex = vertices[start];
            Vertex nextVertex;
            do
            {
                currentPath.Push(currentVertex);
                foreach (string neighbor in currentVertex.adjacencies)
                {
                    nextVertex = vertices[neighbor];
                    int distance = weights[vertexIndices.IndexOf(currentVertex.Name)][currentVertex.adjacencies.IndexOf(neighbor)];
                    if (Math.Min(nextVertex.distance, currentVertex.distance + distance) != nextVertex.distance)
                    {
                        nextVertex.distance = currentVertex.distance + distance;
                        nextVertex.nearestNeighbor = currentVertex;
                    }
                }
                currentVertex.completed = true;
                currentVertex = GetAdjacentUnvisited(currentVertex);
                currentPath.Pop();
                currentVertex = currentPath.Peek();
            } while (currentPath.Count > 0);
        }

        public Vertex GetAdjacentUnvisited(Vertex vertex)
        {
            foreach(string neighbor in vertex.adjacencies)
            {
                if (!vertices[neighbor].completed) return vertices[neighbor];
            }
            return null;
        }

        private int CurrentPathLength(Stack<Vertex> stack)
        {
            Vertex[] stackArray= stack.ToArray();
            int result = 0;
            for (int i = 0; i < stackArray.Length - 1; i++)
                result += weights[vertexIndices.IndexOf(stackArray[i].Name)][vertexIndices.IndexOf(stackArray[i+1].Name)];
            return result;
        }

        private void SetUpVertices()
        {
            vertices = new Dictionary<string, Vertex>();
            vertices.Add("Hub", new Vertex("Hub", new List<string> { "Invisible", "Dragons' Sky", "Virtual", "Undead"}));
            vertices.Add("Invisible", new Vertex("Invisible", new List<string> { "Hub", "Dragon's Sky", "Virtual"}));
            vertices.Add("Dragons' Sky", new Vertex("Dragons' Sky", new List<string> { "Hub", "Invisible"}));
            vertices.Add("Virtual", new Vertex("Virtual", new List<string> { "Hub", "Undead", "Invisible", "???"}));
            vertices.Add("Undead", new Vertex("Undead", new List<string> { "Hub", "Virtual", "???"}));
            vertices.Add("???", new Vertex("???", new List<string> { "Virtual", "Undead"}));
            vertexIndices = new List<string>();
            vertexIndices.Add("Hub");
            vertexIndices.Add("Invisible");
            vertexIndices.Add("Dragons' Sky");
            vertexIndices.Add("Virtual");
            vertexIndices.Add("Undead");
            vertexIndices.Add("???");
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
