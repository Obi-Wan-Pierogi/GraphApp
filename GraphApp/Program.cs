using GraphLib;

DirectedGraph graph = new DirectedGraph();

var a = graph.AddVertex("A");
var b = graph.AddVertex("B");
var c = graph.AddVertex("C");
var d = graph.AddVertex("D");
var e = graph.AddVertex("E");
var f = graph.AddVertex("F");
var g = graph.AddVertex("G");
var h = graph.AddVertex("H");
var i = graph.AddVertex("I");

a.AddEdge(b, 4).AddEdge(c, 0).AddEdge(d, 0).AddEdge(e, 0).AddEdge(f, 0).AddEdge(g, 0).AddEdge(h, 8).AddEdge(i, 0);
b.AddEdge(c, 8).AddEdge(d, 0).AddEdge(e, 0).AddEdge(f, 0).AddEdge(g, 0).AddEdge(h, 11).AddEdge(i, 0); ;
c.AddEdge(d, 7).AddEdge(e, 0).AddEdge(f, 4).AddEdge(g, 0).AddEdge(h, 0).AddEdge(i, 2);
d.AddEdge(e, 9).AddEdge(f, 14).AddEdge(g, 0).AddEdge(h, 0).AddEdge(i, 0);
e.AddEdge(f, 10).AddEdge(g, 0).AddEdge(h, 0).AddEdge(i, 0);
f.AddEdge(g, 2).AddEdge(h, 0).AddEdge(i, 0);
g.AddEdge(h, 1).AddEdge(i, 6);
h.AddEdge(i, 7);

graph.PrintMatrix();
Console.WriteLine();

graph.Dijkstra(5);
Console.WriteLine();

DirectedGraph directedGraph = new DirectedGraph();
var a2 = directedGraph.AddVertex("A");
var b2 = directedGraph.AddVertex("B");
var c2 = directedGraph.AddVertex("C");
var d2 = directedGraph.AddVertex("D");
var e2 = directedGraph.AddVertex("E");
var f2 = directedGraph.AddVertex("F");
var g2 = directedGraph.AddVertex("G");

a2.AddEdge(b2, 7).AddEdge(c2, 3).AddEdge(d2, 7);
b2.AddEdge(c2, 1);
c2.AddEdge(e2, 32).AddEdge(f2, 3);
d2.AddEdge(e2, 2).AddEdge(g2, 1);
e2.AddEdge(f2, 9);
f2.AddEdge(g2, 7);


Console.WriteLine("Graph #2");
directedGraph.PrintMatrix();
Console.WriteLine();
directedGraph.Dijkstra(0);


