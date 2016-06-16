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
            Tree tree = new Tree();

            tree.AddEdge(0, 1);

            List<int> actualPath = tree.BFS(0, 1);
            List<int> expectedPath = new List<int> { 1, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Tree tree = new Tree();

            tree.AddEdge(0, 1);
            tree.AddEdge(1, 2);

            List<int> actualPath = tree.BFS(0, 1);
            List<int> expectedPath = new List<int> { 1, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Tree tree = new Tree();

            tree.AddEdge(0, 1);
            tree.AddEdge(1, 2);

            List<int> actualPath = tree.BFS(0, 2);
            List<int> expectedPath = new List<int> { 2, 1, 0 };

            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Tree tree = new Tree();

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
            Tree tree = new Tree();

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
    }
}
