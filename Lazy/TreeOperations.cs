using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy
{
    public class TreeOperations
    {
        private IGraph tree = new DictionaryTree();

        // Node reference.
        private Dictionary<int, Node> nodeRef = new Dictionary<int, Node>();

        public void AddEdge(int a, int b)
        {
            tree.AddEdge(a, b);
            tree.AddEdge(b, a);
        }

        public void SetNodeValue(int nodeId, int value)
        {
            if (nodeRef.ContainsKey(nodeId))
            {
                nodeRef[nodeId].Value = value;
            }
            else
            {
                nodeRef.Add(nodeId, new Node { Value = value });
            }
        }

        public int GetNodeValue(int nodeId)
        {
            if (nodeRef.ContainsKey(nodeId))
            {
                return nodeRef[nodeId].Value;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Get the height of a node.
        /// </summary>
        /// <param name="nodeId">The node.</param>
        /// <returns>The height of the node. The root node height is 0.</returns>
        public int GetHeight(int nodeId)
        {
            int height = 0;
            int parent = nodeRef[nodeId].Prev;
            while(parent != -1)
            {
                parent = nodeRef[parent].Prev;
                height++;
            }

            return height;
        }

        public int FindCommonAncestor(int a, int b)
        {
            // If the nodes are the same, then the common ancestor is that node.
            if (a == b)
            {
                return a;
            }

            // Get the height of both nodes.
            int heightA = GetHeight(a);
            int heightB = GetHeight(b);

            // Iterate through parents until the common ancestor is found.
            while (a != b)
            {
                if (heightA > heightB)
                {
                    a = nodeRef[a].Prev;
                    heightA--;
                }
                else if (heightB > heightA)
                {
                    b = nodeRef[b].Prev;
                    heightB--;
                }
                else
                {
                    a = nodeRef[a].Prev;
                    b = nodeRef[b].Prev;
                    heightA--;
                    heightB--;
                }
            }

            return a;
        }

        public Dictionary<int, Node> BuildRootedTree(int rootNodeId)
        {
            if (tree.ContainsNode(rootNodeId) == false)
            {
                throw new Exception("tree does not contain node " + rootNodeId);
            }

            nodeRef = new Dictionary<int, Node>();

            List<int> neighbours;
            Queue<int> toVisit = new Queue<int>();

            // Add the root node which has no previous node.
            toVisit.Enqueue(rootNodeId);
            nodeRef.Add(rootNodeId, new Node { Prev = -1 });

            while (toVisit.Count > 0)
            {
                // Obtain the next node to visit.
                int curr = toVisit.Dequeue();

                // Obtain the neighbours.
                neighbours = tree.GetNeighbours(curr);

                for (int i = 0; i < neighbours.Count; ++i)
                {
                    if (!nodeRef.ContainsKey(neighbours[i]))
                    {
                        // Only add unvisited neighbours to the queue.
                        toVisit.Enqueue(neighbours[i]);

                        // Add the new node which is a child of the current node.
                        nodeRef.Add(neighbours[i], new Node { Prev = curr });
                    }
                }
            }

            return nodeRef;
        }

        public List<int> BFS(int a, int b)
        {
            if (tree.ContainsNode(a) == false || tree.ContainsNode(b) == false)
            {
                return null;
            }

            List<int> neighbours;
            List<Node> visited = new List<Node>();
            Queue<int> toVisit = new Queue<int>();
            Dictionary<int, bool> visitedDict = new Dictionary<int, bool>();

            toVisit.Enqueue(a);
            visited.Add(new Node { Value = a, Prev = -1 });
            visitedDict.Add(a, true);

            int fromIndex = 0;
            while (toVisit.Count > 0)
            {
                // Obtain the next node to visit.
                int curr = toVisit.Dequeue();

                // Are we at the destination node?
                if (curr == b)
                {
                    break;
                }

                // Obtain the neighbours.
                neighbours = tree.GetNeighbours(curr);// PERFORMANCE: Changing from dictionary to list reduced from 18.1% to 8.0%

                // Only add unvisited neighbours to the queue.
                // foreach (int neighbour in neighbours) // PERFORMANCE: Reduced from 24.9% to 18.8%
                for (int i = 0; i < neighbours.Count; ++i)
                {
                    if (!visitedDict.ContainsKey(neighbours[i]))
                    {
                        toVisit.Enqueue(neighbours[i]);
                        visited.Add(new Node { Value = neighbours[i], Prev = fromIndex });
                        visitedDict.Add(neighbours[i], true);
                    }
                }

                fromIndex++;
            }

            // Backtrack through visited list to obtain the path.
            List<int> path = new List<int>();
            for (int i = fromIndex; i >= 0; i = visited[i].Prev)
            {
                path.Add(visited[i].Value);
            }
            return path;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            /*foreach (KeyValuePair<int, List<int>> entry in tree)
            {
                sb.Append(entry.Key + ":");
                foreach (int nodeId in entry.Value)
                {
                    sb.Append(" " + nodeId);
                }
                sb.AppendLine();
            }*/

            return sb.ToString();
        }
    }
}
