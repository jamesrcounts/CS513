using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimsAlgorithm
{
    internal class Program
    {
        private static void Main()
        {
            Vertex[] nodes = new Vertex[]
            {
                new Vertex("a"),
                new Vertex("b"),
                new Vertex("c"),
                new Vertex("d"),
                new Vertex("e"),
                new Vertex("f"),
                new Vertex("g"),
                new Vertex("h"),
                new Vertex("i"),
                new Vertex("j"),
                new Vertex("k"),
                new Vertex("l"),
            };
            Edge[] edges = new[]
            {
                new Edge(3, nodes[0], nodes[1]),
                new Edge(5, nodes[0], nodes[2]),
                new Edge(4, nodes[0], nodes[3]),
                new Edge(3, nodes[1], nodes[4]),
                new Edge(6, nodes[1], nodes[5]),
                new Edge(2, nodes[2], nodes[3]),
                new Edge(1, nodes[3], nodes[4]),
                new Edge(2, nodes[4], nodes[5]),
                new Edge(4, nodes[2], nodes[6]),
                new Edge(5, nodes[3], nodes[7]),
                new Edge(4, nodes[4], nodes[8]),
                new Edge(5, nodes[5], nodes[9]),
                new Edge(3, nodes[6], nodes[7]),
                new Edge(6, nodes[7], nodes[8]),
                new Edge(3, nodes[8], nodes[9]),
                new Edge(6, nodes[6], nodes[10]),
                new Edge(7, nodes[7], nodes[10]),
                new Edge(5, nodes[8], nodes[11]),
                new Edge(9, nodes[9], nodes[11]),
                new Edge(8, nodes[10], nodes[11]),
            };
            Console.WriteLine(string.Join(", ", Prim(nodes, edges)));
        }

        private static IEnumerable<Edge> Prim(Vertex[] nodes, Edge[] edges)
        {
            var treeNodes = new List<Vertex> { nodes.First() };
            var treeEdges = new List<Edge>();
            var fringe = new List<Vertex>();

            Console.WriteLine("Tree vertices | Priority queue of fringe vertices");
            for (int i = 1; i < nodes.Length; i++)
            {
                var remainder = nodes.Where(n => !treeNodes.Contains(n));
                foreach (var r in remainder)
                {
                    if (r.IsAdjacentTo(treeNodes, edges) &&
                        !fringe.Contains(r))
                    {
                        fringe.Add(r);
                    }
                }

                Console.WriteLine("{1} | {0}", string.Join(", ", fringe), treeNodes.Last());

                var min = fringe.OrderBy(n => n.Cost).First();
                fringe.Remove(min);
                treeNodes.Add(min);
                treeEdges.Add(min.Edge);
            }

            Console.WriteLine("{1} | {0}", string.Join(", ", fringe), treeNodes.Last());
            return treeEdges;
        }
    }
}