using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace GraphLib
{
    public class DirectedGraph
    {
        private static readonly int NO_PARENT = -1;
        public int NumVertices { get => Vertices.Count; }
        public List<Vertex> Vertices = new List<Vertex>();

        public Vertex AddVertex(string label)
        {
            Vertex v = new Vertex(label);

            Vertices.Add(v);

            return v;
        }

        public int[,] CreateAdjMatrix()
        {
            // make a 2d array to represent all verticies
            int[,] AdjMatrix = new int[Vertices.Count,Vertices.Count];

            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertex v1 = Vertices[i];

                for (int j = 0; j < Vertices.Count; j++)
                {
                    Vertex v2 = Vertices[j];

                    Edge edge = v1.Edges.FirstOrDefault(e => e.Child == v2);

                    if (edge != null)
                    {
                        AdjMatrix[i, j] = edge.Weight;
                    }
                }
            }

            return AdjMatrix;
        }

        public void PrintMatrix()
        {
            var matrix = CreateAdjMatrix();

            Console.Write("  ");
            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write($" {Vertices[i].Label} ");
            }
            Console.WriteLine();


            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write($"{Vertices[i].Label} ");

                for (int j = 0; j < Vertices.Count; j++)
                {
                    if (matrix[i, j] != null)
                    {
                        Console.Write($"[{matrix[i, j].ToString()}]");
                    }
                    else
                    {
                        Console.Write("[.]");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Dijkstra(int[,] graph, int src)
        {           
            // set up some buckets to store our info
            int[] dist = new int[Vertices.Count];
            bool[] visits = new bool[Vertices.Count];

            // initialize the arrays
            for (int i = 0; i < Vertices.Count; i++)
            {
                dist[i] = int.MaxValue;
                visits[i] = false;
            }

            dist[src] = 0;

            // parent array to store the shortest path tree
            int[] parents = new int[Vertices.Count];

            // the parent of the source is none
            parents[src] = NO_PARENT;

            for (int count = 0; count < Vertices.Count - 1; count++)
            {
                // pick minimum distance vertex from the set of vertices not yet processed
                int u = MinDistance(dist, visits);

                // mark the picked vertex as visited
                visits[u] = true;

                // update dist value of the adjacent vertices of the picked vertex
                for (int v = 0; v < Vertices.Count; v++)
                {
                    /*
                     update dist[v] only if the following conditions are true:
                        it is not visited,
                        there exists an edge from u to v,
                        the edge is not infinity,
                        the total weight of the path from src to v through the picked node (u) is smaller than the current value of dist[v]
                     */

                    if (!visits[v] && graph[u, v] != 0
                        && dist[u] != int.MaxValue
                        && dist[u] + graph[u, v] < dist[v]
                        )
                    {
                        dist[v] = dist[u] + graph[u, v];
                        parents[v] = u;
                    }
                }
            }

            PrintSolution(dist, src, parents);

        }

        private void PrintSolution(int[] dist, int src, int[] parents)
        {
            Console.WriteLine("Vertex\t Distance\tPath");

            // print the shortest path from the source to each vertex
            for (int i = 0; i < Vertices.Count; i++)
                if (i != src)
                {
                    Console.Write($"{Vertices[src].Label } -> {Vertices[i].Label} \t {dist[i]} \t\t");
                    PrintPath(i, parents, Vertices);
                    Console.WriteLine();                  
                }
                else
                {
                    // print the source
                    Console.WriteLine($"{Vertices[i].Label} \t SRC \t\t ");
                }

        }

        private static void PrintPath(int j, int[] parents, List<Vertex> vertices)
        {
            // base case : if j is source
            if (j == NO_PARENT)
            {
                return;
            }

            // recursively print the parent of the current node
            PrintPath(parents[j], parents, vertices); 
            Console.Write(vertices[j].Label + " "); 
        }

        int MinDistance(int[] dist, bool[] visits)
        {
            int min = int.MaxValue;
            int min_index = -1;

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (visits[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    min_index = i;
                }
            }
            return min_index;
        }
    }
}
