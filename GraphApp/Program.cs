// See https://aka.ms/new-console-template for more information

using GraphLib;

var graph = new DirectedGraph();

var a = graph.CreateVertex("A");
var b = graph.CreateVertex("B");
var c = graph.CreateVertex("C");
var d = graph.CreateVertex("D");
var e = graph.CreateVertex("E");
var f = graph.CreateVertex("F");
var g = graph.CreateVertex("G");
var h = graph.CreateVertex("H");
var i = graph.CreateVertex("I");
var j = graph.CreateVertex("J");
var k = graph.CreateVertex("K");
var l = graph.CreateVertex("L");
var m = graph.CreateVertex("M");
var n = graph.CreateVertex("N");
var o = graph.CreateVertex("O");
var p = graph.CreateVertex("P");

a.AddEdge(b, 1)
 .AddEdge(c, 1);

b.AddEdge(e, 1)
 .AddEdge(d, 3);

c.AddEdge(f, 1)
 .AddEdge(d, 3);

c.AddEdge(f, 1)
 .AddEdge(d, 3);

d.AddEdge(h, 8);

e.AddEdge(g, 1)
 .AddEdge(h, 3);

f.AddEdge(h, 3)
 .AddEdge(i, 1);

g.AddEdge(j, 3)
 .AddEdge(l, 1);

h.AddEdge(j, 8)
 .AddEdge(k, 8)
 .AddEdge(m, 3);

i.AddEdge(k, 3)
 .AddEdge(n, 1);

j.AddEdge(o, 3);

k.AddEdge(p, 3);

l.AddEdge(o, 1);

m.AddEdge(o, 1)
 .AddEdge(p, 1);

n.AddEdge(p, 1);

// o - Already added

// p - Already added

int?[,] adj = graph.CreateAdjMatrix();

graph.PrintMatrix(ref adj, graph.Vertices.Count);