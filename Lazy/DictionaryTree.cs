using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy
{
    public class DictionaryTree : ITree
    {
        // Tree structure.
        private Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();

        public void AddEdge(int key, int value)
        {
            if (tree.ContainsKey(key))
            {
                tree[key].Add(value);
            }
            else
            {
                tree.Add(key, new List<int>());
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
