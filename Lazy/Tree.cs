﻿using System;
using System.Collections.Generic;
using System.Text;

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

    public interface ITree
    {
        void AddEdge(int key, int value);
        bool ContainsNode(int nodeId);
        List<int> GetNeighbours(int nodeId);
    }

    public class TreeArray : ITree
    {
        private List<int>[] tree = new List<int>[20000];

        public void AddEdge(int key, int value)
        {
            if(tree[key] != null)
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

    public class TreeDictionary : ITree
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

    public class Tree
    {
        private ITree tree = new TreeDictionary();

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
                neighbours = GetNeighbours(curr);// PERFORMANCE: Changing from dictionary to list reduced from 18.1% to 8.0%

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
            for(int i = fromIndex; i >= 0; i = visited[i].Prev)
            {
                path.Add(visited[i].Value);
            }
            return path;
        }

        private List<int> GetNeighbours(int nodeId)
        {
            return tree.GetNeighbours(nodeId);
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