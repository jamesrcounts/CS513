using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimsAlgorithm
{
    public class Edge
    {
        private readonly Vertex[] Ends;

        public Edge(int cost, Vertex v, Vertex u)
        {
            Cost = cost;
            Ends = new[] { v, u };
        }

        public int Cost { get; set; }

        public bool ConnectedTo(params Vertex[] treeNodes)
        {
            return treeNodes.Any(n => Ends.Contains(n));
        }

        public Vertex OtherNode(Vertex that)
        {
            return Ends.Where(v => v != that).Single();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1},{2})", Cost, this.Ends[0].Name, this.Ends[1].Name);
        }
    }
}