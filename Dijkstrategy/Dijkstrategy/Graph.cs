using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstrategy
{
    class Graph
    {
        int[][] matrix;
        Dictionary<string, Vertex> vertexNames;
        List<Vertex> vertexIndices;

        int pathLength; //Current length, used for pathfinding
        List<Vertex> path; //Final path

        public Graph()
        {
            SetUpVertices();
            pathLength = 0;
            path = new List<Vertex>();
            path.Add(vertexIndices[0]);
        }

        public void Reset()
        {
            foreach (Vertex vertex in vertexIndices) vertex.completed = false;
            pathLength = 0;
            path = new List<Vertex>();
            path.Add(vertexIndices[0]);
        }

        public void ShortestPath()
        {

        }

        public Vertex GetAdjacentUnvisited(String name)
        {
            Vertex vertex = vertexNames[name];
            int index = vertexIndices.IndexOf(vertex); //Index of the matrix within vertexNames and thus also the adjacency matrix
            for (int i = 0; i < matrix[index].Length; i++)
            {
                if (i >= index) { //Finds which vertex this is, and the matrix skips self-comparison
                    Vertex adjacent = vertexIndices[i + 1];
                }
                else {
                    Vertex adjacent = vertexIndices[i];
                }
                if (matrix[index][i] != -1 && !vertex.completed) return vertex;
            }
            return null;
        }

        private void SetUpVertices()
        {
            matrix = new int[4][];
            matrix[0] = new int[] { 2, 3, -1, 9};
            matrix[1] = new int[] { -1, 2, 5, -1};
            matrix[2] = new int[] { -1, -1, 4, 6};
            matrix[3] = new int[] { -1, -1, -1, 3};
            vertexIndices = new List<Vertex>();
            vertexIndices.Add(new Vertex("Dragons' Sky"));
            vertexIndices.Add(new Vertex("Invisible"));
            vertexIndices.Add(new Vertex("Hub"));
            vertexIndices.Add(new Vertex("Undead"));
            vertexIndices.Add(new Vertex("???"));
            vertexNames = new Dictionary<string, Vertex>();
            foreach (Vertex vertex in vertexIndices) vertexNames.Add(vertex.Name, vertex);
        }
    }
}
