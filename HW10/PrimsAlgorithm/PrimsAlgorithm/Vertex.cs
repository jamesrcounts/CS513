using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimsAlgorithm
{
    public class Vertex
    {
        public Vertex(string name)
        {
            Name = name;
        }

        public string Cost
        {
            get
            {
                return this.Edge == null ?
                    "-" :
                    this.Edge.Cost.ToString();
            }
        }

        public Edge Edge { get; set; }

        public string Name { get; set; }

        public bool IsAdjacentTo(List<Vertex> treeNodes, Edge[] edges)
        {
            var connectingEdges = from e in edges
                                  where e.ConnectedTo(treeNodes.ToArray())
                                  && e.ConnectedTo(this)
                                  orderby e.Cost
                                  select e;
            this.Edge = connectingEdges.FirstOrDefault();
            return this.Edge != null;
        }

        public override string ToString()
        {
            string other = this.Edge == null ? "-" : this.Edge.OtherNode(this).Name;
            return string.Format("{0} ({1}, {2})", Name, other, this.Cost);
        }
    }
}