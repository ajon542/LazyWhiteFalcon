using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy
{
    public class ArrayTree : ITree
    {
        private List<int>[] tree = new List<int>[20000];

        public void AddEdge(int key, int value)
        {
            if (tree[key] != null)
            {
                tree[key].Add(value);
            }
            else
            {
                tree[key] = new List<int>();
                tree[key].Add(value);
            }
        }

        public bool ContainsNode(int nodeId)
        {
            if (tree[nodeId] == null)
            {
                return false;
            }

            return true;
        }

        public List<int> GetNeighbours(int nodeId)
        {
            return tree[nodeId];
        }
    }
}
