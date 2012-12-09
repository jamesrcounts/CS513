using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalsAlgorithm
{
    public class Tree
    {
        private readonly IEnumerable<Vertex> Nodes;
        private readonly IEnumerable<Edge> paths;

        public Tree(IEnumerable<Vertex> v, IEnumerable<Edge> e)
        {
            Nodes = v;
            paths = e ?? Enumerable.Empty<Edge>();
        }

        public IEnumerable<Edge> Edges
        {
            get
            {
                return paths;
            }
        }

        public Tree Union(Tree t, Edge e)
        {
            var es = new[] { e };
            es = es.Concat(Edges).ToArray();
            es = es.Concat(t.Edges).ToArray();

            var ns = Nodes.Concat(t.Nodes);

            return new Tree(ns.ToArray(), es.ToArray());
        }

        internal bool Contains(Vertex v)
        {
            return Nodes.Contains(v);
        }

        public override string ToString()
        {
            return 0 < Edges.Count() ?
                string.Format("[{0}]", string.Join(", ", Edges)) :
                Nodes.First().Name;
        }
    }
}