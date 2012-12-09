using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalsAlgorithm
{
    internal class Program
    {
        private static IEnumerable<Edge> Kruskal(Vertex[] nodes, Edge[] edges)
        {
            var workingEdges = new Queue<Edge>(edges.OrderBy(e => e.Cost).ToArray());
            var forest = MakeSet(nodes).ToArray();
            Console.WriteLine("Forest: {0}", string.Join<Tree>("|", forest));

            while (1 < forest.Count())
            {
                var edge = workingEdges.Dequeue();
                var vtrees = TreesWith(edge.Ends[0], forest).ToArray();
                var utrees = TreesWith(edge.Ends[1], forest).ToArray();
                if (0 < vtrees.Length && 0 < utrees.Length)
                {
                    forest = MakeUnions(vtrees, utrees, edge, forest).ToArray();
                    Console.WriteLine("Forest: {0}", string.Join<Tree>("|", forest));
                }
            }

            return forest.First().Edges;
        }

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
            Console.WriteLine(string.Join(", ", Kruskal(nodes, edges)));
        }

        private static IEnumerable<Tree> MakeSet(Vertex[] nodes)
        {
            foreach (var n in nodes)
            {
                yield return new Tree(new[] { n }, null);
            }
        }

        private static IEnumerable<Tree> MakeUnions(IEnumerable<Tree> vtrees, IEnumerable<Tree> utrees, Edge e, IEnumerable<Tree> forest)
        {
            var f = forest.Where(t => !vtrees.Contains(t) && !utrees.Contains(t)).ToArray();
            var unions = from v in vtrees
                         from u in utrees
                         where v != u
                         select v.Union(u, e);
            return unions.Any() ? unions.Concat(f) : forest;
        }

        private static IEnumerable<Tree> TreesWith(Vertex v, IEnumerable<Tree> forest)
        {
            return from f in forest
                   where f.Contains(v)
                   select f;
        }
    }
}