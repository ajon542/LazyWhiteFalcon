using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lazy
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Don't hardcode these.
            string input = "D:\\development\\GitHub\\LazyWhiteFalcon\\TestCases\\input04.txt";
            string output = "D:\\development\\GitHub\\LazyWhiteFalcon\\TestCases\\output04.txt";

            // Read the expected output file.
            List<string> expectedResult = new List<string>();
            using (StreamReader file = new StreamReader(output))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    expectedResult.Add(line);
                }
            }

            Stopwatch totalTime = Stopwatch.StartNew();
            Stopwatch splitTime = Stopwatch.StartNew();

            // Read and process input file.
            List<string> actualResult = new List<string>();
            using (StreamReader file = new StreamReader(input))
            {
                string line = file.ReadLine();
                string[] strArr = line.Split();
                int nodeCount = Convert.ToInt32(strArr[0]);
                int queryCount = Convert.ToInt32(strArr[1]);

                Tree tree = new Tree();

                // Read the edges from input.
                for (int i = 0; i < nodeCount - 1; ++i)
                {
                    line = file.ReadLine();
                    strArr = line.Split();

                    // Add the edge to the tree.
                    int nodeA = Convert.ToInt32(strArr[0]);
                    int nodeB = Convert.ToInt32(strArr[1]);
                    tree.AddEdge(nodeA, nodeB);
                }

                // Read the queries from input.
                for (int i = 0; i < queryCount; ++i)
                {
                    if(i % 100 == 0)
                    {
                        splitTime.Stop();
                        Console.WriteLine(i + " " + splitTime.ElapsedMilliseconds);
                        splitTime.Restart();
                    }
                    line = file.ReadLine();
                    strArr = line.Split();

                    int queryType = Convert.ToInt32(strArr[0]);
                    int u = Convert.ToInt32(strArr[1]);
                    int v = Convert.ToInt32(strArr[2]);

                    // Update the node values.
                    if (queryType == 1)
                    {
                        tree.SetNodeValue(u, v);
                    }

                    // Calculate the sum.
                    if (queryType == 2)
                    {
                        int sum = 0;
                        List<int> path = tree.BFS(u, v);
                        foreach (int nodeId in path)
                        {
                            sum += tree.GetNodeValue(nodeId);
                        }
                        actualResult.Add(sum.ToString());
                    }
                }
            }

            // Stop the timers.
            splitTime.Stop();
            totalTime.Stop();
            Console.WriteLine("Total Time: " + totalTime.ElapsedMilliseconds);

            // Compare the result and expected output.
            for (int i = 0; i < expectedResult.Count; ++i)
            {
                if(expectedResult[i] != actualResult[i])
                {
                    throw new Exception();
                }
            }

            Console.WriteLine("Test Passed");
            Console.ReadLine();
        }
    }
}
