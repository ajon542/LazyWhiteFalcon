using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy
{
    public class ArrayTree : IGraph
    {
        private List<int>[] tree = new List<int>[20000];

        public void AddEdge(int nodeId1, int nodeId2)
        {
            if (tree[nodeId1] != null)
            {
                tree[nodeId1].Add(nodeId2);
            }
            else
            {
                tree[nodeId1] = new List<int>();
                tree[nodeId1].Add(nodeId2);
            }
        }

        public void RemoveEdge(int nodeId1, int nodeId2)
        {
            throw new NotImplementedException();
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
