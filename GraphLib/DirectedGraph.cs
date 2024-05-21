using System.Xml.Linq;

namespace GraphLib
{
    public class DirectedGraph
    {
        public List<Vertex> Vertices = new List<Vertex>();

        public Vertex CreateVertex(string name)
        {
            Vertex v = new Vertex(name);
            Vertices.Add(v);
            return v;
        }

        public int?[,] CreateAdjMatrix()
        {
            int?[,] adj = new int?[Vertices.Count, Vertices.Count];

            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertex v1 = Vertices[i];

                for (int j = 0; j < Vertices.Count; j++)
                {
                    Vertex v2 = Vertices[j];

                    var edge = v1.Edges.FirstOrDefault(a => a.Child == v2);

                    if (edge != null)
                    {
                        adj[i, j] = edge.Weight;
                    }
                }
            }

            return adj;
        }

        public void PrintMatrix(ref int?[,] matrix, int Count)
        {
            Console.Write("       ");
            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0}  ", (char)('A' + i));
            }

            Console.WriteLine();

            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0} | [ ", (char)('A' + i));

                for (int j = 0; j < Count; j++)
                {
                    if (i == j)
                    {
                        Console.Write(" &,");
                    }
                    else if (matrix[i, j] == null)
                    {
                        Console.Write(" .,");
                    }
                    else
                    {
                        Console.Write(" {0},", matrix[i, j]);
                    }

                }
                Console.Write(" ]\r\n");
            }
            Console.Write("\r\n");
        }
    }
}
