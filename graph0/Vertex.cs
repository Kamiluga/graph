using System;
using System.Collections.Generic;

namespace graph0
{
    public class Vertex: IComparable<Vertex>, IComparer<Vertex>
    {
        public string Name { get; set; }

        public Vertex(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Vertex other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        public int Compare(Vertex x, Vertex y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vertex vertex)
            {
                return Name == vertex.Name;
            }

            return false;
        }

        protected bool Equals(Vertex other)
        {
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}