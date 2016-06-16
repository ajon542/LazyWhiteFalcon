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

        public void AddEdge(int nodeId1, int nodeId2)
        {
            if (tree.ContainsKey(nodeId1))
            {
                tree[nodeId1].Add(nodeId2);
            }
            else
            {
                tree.Add(nodeId1, new List<int>());
                tree[nodeId1].Add(nodeId2);
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
