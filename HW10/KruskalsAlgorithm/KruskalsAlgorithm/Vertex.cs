using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalsAlgorithm
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

        public override string ToString()
        {
            string other = this.Edge == null ? "-" : this.Edge.OtherNode(this).Name;
            return string.Format("{0} ({1}, {2})", Name, other, this.Cost);
        }
    }
}