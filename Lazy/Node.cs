using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy
{
    public class Node
    {
        public int Value { get; set; }

        // Previous node is used for backtracking during the bfs.
        public int Prev { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}", Value);

            return sb.ToString();
        }
    }
}
