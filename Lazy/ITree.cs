﻿using System.Collections.Generic;

namespace Lazy
{
    /// <summary>
    /// Interface for a tree.
    /// </summary>
    public interface ITree
    {
        /// <summary>
        /// Adds an edge between two nodes. The edge is directed from nodeId1 -> nodeId2.
        /// </summary>
        /// <param name="nodeId1">The edge start node.</param>
        /// <param name="nodeId2">The edge end node.</param>
        void AddEdge(int nodeId1, int nodeId2);

        /// <summary>
        /// Checks if the given node is in the tree.
        /// </summary>
        /// <param name="nodeId">The node to check.</param>
        /// <returns>True if the node is in the tree, false otherwise.</returns>
        bool ContainsNode(int nodeId);

        /// <summary>
        /// Gets the neighbouring nodes.
        /// </summary>
        /// <param name="nodeId">The node to get the neighbours for.</param>
        /// <returns>The list of neighbouring nodes, or null.</returns>
        List<int> GetNeighbours(int nodeId);
    }
}
