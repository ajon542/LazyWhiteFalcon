using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Lazy;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);

            List<int> actualPath = tree.BFS(0, 1);
            List<int> expectedPath = new List<int> { 1, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void TestMethod2()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);
            tree.AddEdge(1, 2);

            List<int> actualPath = tree.BFS(0, 1);
            List<int> expectedPath = new List<int> { 1, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void TestMethod3()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);
            tree.AddEdge(1, 2);

            List<int> actualPath = tree.BFS(0, 2);
            List<int> expectedPath = new List<int> { 2, 1, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void TestMethod4()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);
            tree.AddEdge(0, 2);

            List<int> actualPath = tree.BFS(0, 1);
            List<int> expectedPath = new List<int> { 1, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);

            actualPath = tree.BFS(0, 2);
            expectedPath = new List<int> { 2, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void TestMethod5()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);
            tree.AddEdge(0, 2);
            tree.AddEdge(1, 3);

            List<int> actualPath = tree.BFS(0, 1);
            List<int> expectedPath = new List<int> { 1, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);

            actualPath = tree.BFS(0, 2);
            expectedPath = new List<int> { 2, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);

            actualPath = tree.BFS(0, 3);
            expectedPath = new List<int> { 3, 1, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);

            actualPath = tree.BFS(3, 1);
            expectedPath = new List<int> { 1, 3 };

            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void TestMethod6()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);

            // Build rooted tree from node 0.
            Dictionary<int, Node> rootedTree = tree.BuildRootedTree(0);
            Assert.AreEqual(rootedTree[0].Prev, -1);
            Assert.AreEqual(rootedTree[1].Prev, 0);

            // Build rooted tree from node 1.
            rootedTree = tree.BuildRootedTree(1);
            Assert.AreEqual(rootedTree[1].Prev, -1);
            Assert.AreEqual(rootedTree[0].Prev, 1);
        }

        [TestMethod]
        public void TestMethod7()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);
            tree.AddEdge(1, 2);
            tree.AddEdge(2, 3);
            tree.AddEdge(3, 4);

            // Build rooted tree from node 0.
            Dictionary<int, Node> rootedTree = tree.BuildRootedTree(0);
            Assert.AreEqual(rootedTree[0].Prev, -1);
            Assert.AreEqual(rootedTree[1].Prev, 0);
            Assert.AreEqual(rootedTree[2].Prev, 1);
            Assert.AreEqual(rootedTree[3].Prev, 2);
            Assert.AreEqual(rootedTree[4].Prev, 3);

            // Build rooted tree from node 4.
            rootedTree = tree.BuildRootedTree(4);
            Assert.AreEqual(rootedTree[4].Prev, -1);
            Assert.AreEqual(rootedTree[3].Prev, 4);
            Assert.AreEqual(rootedTree[2].Prev, 3);
            Assert.AreEqual(rootedTree[1].Prev, 2);
            Assert.AreEqual(rootedTree[0].Prev, 1);

            // Build rooted tree from node 2.
            rootedTree = tree.BuildRootedTree(2);
            Assert.AreEqual(rootedTree[2].Prev, -1);
            Assert.AreEqual(rootedTree[1].Prev, 2);
            Assert.AreEqual(rootedTree[3].Prev, 2);
            Assert.AreEqual(rootedTree[4].Prev, 3);
            Assert.AreEqual(rootedTree[0].Prev, 1);
        }

        [TestMethod]
        public void TestMethod8()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);

            // Build rooted tree from node 0.
            Dictionary<int, Node> rootedTree = tree.BuildRootedTree(0);

            // Height of root node should be 0.
            Assert.AreEqual(0, tree.GetHeight(0));

            // Height of child node should be 1.
            Assert.AreEqual(1, tree.GetHeight(1));
        }

        [TestMethod]
        public void TestMethod9()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);
            tree.AddEdge(1, 2);
            tree.AddEdge(1, 3);
            tree.AddEdge(2, 4);
            tree.AddEdge(3, 5);

            // Build rooted tree from node 0.
            Dictionary<int, Node> rootedTree = tree.BuildRootedTree(0);

            // Check the heights match.
            Assert.AreEqual(0, tree.GetHeight(0));
            Assert.AreEqual(1, tree.GetHeight(1));
            Assert.AreEqual(2, tree.GetHeight(2));
            Assert.AreEqual(2, tree.GetHeight(3));
            Assert.AreEqual(3, tree.GetHeight(4));
            Assert.AreEqual(3, tree.GetHeight(5));
        }

        [TestMethod]
        public void TestMethod10()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);

            // Build rooted tree from node 0.
            Dictionary<int, Node> rootedTree = tree.BuildRootedTree(0);

            Assert.AreEqual(0, tree.FindCommonAncestor(0, 0));
            Assert.AreEqual(1, tree.FindCommonAncestor(1, 1));
            Assert.AreEqual(0, tree.FindCommonAncestor(0, 1));
        }

        [TestMethod]
        public void TestMethod11()
        {
            TreeOperations tree = new TreeOperations();

            tree.AddEdge(0, 1);
            tree.AddEdge(1, 2);
            tree.AddEdge(1, 3);
            tree.AddEdge(2, 4);
            tree.AddEdge(3, 5);

            // Build rooted tree from node 0.
            Dictionary<int, Node> rootedTree = tree.BuildRootedTree(0);

            Assert.AreEqual(1, tree.FindCommonAncestor(2, 3));
            Assert.AreEqual(1, tree.FindCommonAncestor(4, 5));
            Assert.AreEqual(1, tree.FindCommonAncestor(2, 1));
            Assert.AreEqual(1, tree.FindCommonAncestor(4, 3));
        }
    }
}
