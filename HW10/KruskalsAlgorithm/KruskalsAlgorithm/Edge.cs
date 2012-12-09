using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalsAlgorithm
{
    public class Edge
    {
        private readonly Vertex[] ends;

        public Edge(int cost, Vertex v, Vertex u)
        {
            Cost = cost;
            ends = new[] { v, u };
        }

        public int Cost { get; set; }

        public Vertex[] Ends
        {
            get
            {
                return ends;
            }
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