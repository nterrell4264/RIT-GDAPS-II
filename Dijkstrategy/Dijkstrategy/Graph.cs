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
            currentVertex.distance = 0;
            currentVertex.nearestNeighbor = currentVertex;
            Vertex nextVertex;
            do
            {
                if (!currentVertex.completed)
                {
                    currentPath.Push(currentVertex);
                    foreach (string neighbor in currentVertex.adjacencies)
                    {
                        nextVertex = vertices[neighbor];
                        int distance = weights[vertexIndices.IndexOf(currentVertex.Name)][currentVertex.adjacencies.IndexOf(neighbor)];
                        if (Math.Min(nextVertex.distance, (currentVertex.distance + distance)) != nextVertex.distance)
                        {
                            nextVertex.distance = currentVertex.distance + distance;
                            nextVertex.nearestNeighbor = currentVertex;
                        }
                    }
                    currentVertex.completed = true;
                }
                currentVertex = GetSmallestUnvisited(currentVertex);
                if (currentVertex == null)
                {
                    currentPath.Pop();
                    if(currentPath.Count > 0) currentVertex = currentPath.Peek();
                }
            } while (currentPath.Count > 0);
        }

        public Vertex GetSmallestUnvisited(Vertex vertex)
        {
            KeyValuePair<Vertex, int> smallest = new KeyValuePair<Vertex, int>(null, int.MaxValue);
            foreach (string adjacent in vertex.adjacencies)
            {
                Vertex neighbor = vertices[adjacent];
                if (!neighbor.completed && neighbor.distance <= smallest.Value)
                    smallest = new KeyValuePair<Vertex, int>(neighbor, neighbor.distance);
            }
            return smallest.Key;
        }

        private void SetUpVertices()
        {
            vertices = new Dictionary<string, Vertex>();
            vertices.Add("Hub", new Vertex("Hub", new List<string> { "Invisible", "Dragons' Sky", "Virtual", "Undead"}));
            vertices.Add("Invisible", new Vertex("Invisible", new List<string> { "Hub", "Dragons' Sky", "Virtual"}));
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
            weights[0] = new int[] { 3, 7, 2, 5}; //Hub
            weights[1] = new int[] { 3, 3, 9}; //Invisible
            weights[2] = new int[] { 7, 3}; //Dragons' Sky
            weights[3] = new int[] { 2, 4, 9, 11}; //Virtual
            weights[4] = new int[] { 5, 4, 4}; //Undead
            weights[5] = new int[] { 11, 4}; //???
        }
    }
}
