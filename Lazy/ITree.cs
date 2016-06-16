using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy
{
    public interface ITree
    {
        void AddEdge(int key, int value);
        bool ContainsNode(int nodeId);
        List<int> GetNeighbours(int nodeId);
    }
}
