using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF
{
    public class Edge
    {
        public int StartNode { get; internal set; }
        public int EndNode { get; internal set; }
    }

    public static class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            // Inital sort
            edges.Sort();

            // Set parents table
            var parent = Enumerable.Range(0, numberOfVertices).ToArray();

            // Spanning tree list
            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                var startNodeRoot = FindRoot(edge.StartNode, parent);
                var endNodeRoot = FindRoot(edge.EndNode, parent);

                if (startNodeRoot != endNodeRoot)
                {
                    // Add edge to the spanning tree
                    spanningTree.Add(edge);

                    // Mark one root as parent of the other
                    parent[endNodeRoot] = startNodeRoot;
                }
            }

            // Return the spanning tree
            return spanningTree;
        }

        private static int FindRoot(int node, int[] parent)
        {
            var root = node;
            while (root != parent[root])
            {
                root = parent[root];
            }

            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }
    }
}
