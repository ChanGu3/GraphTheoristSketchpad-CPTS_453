using GTS_GraphEngine;

namespace Testing_GraphEngine
{
    internal class MainMain
    {
        static void Main(string[] args)
        {

            GraphGTSWeighted<string> graphGTS = new GraphGTSWeighted<string>(isDirected: true);

            int v1 = graphGTS.AddVertex();
            int v2 = graphGTS.AddVertex();
            int v3 = graphGTS.AddVertex();
            int v4 = graphGTS.AddVertex();
            int v5 = graphGTS.AddVertex();
            int v6 = graphGTS.AddVertex();
            int v7 = graphGTS.AddVertex();

            int e1 = graphGTS.AddEdge(v1, v2, false, 11);
            int e7 = graphGTS.AddEdge(v1, v2, true, 11);
            int e8 = graphGTS.AddEdge(v2, v1, true, 11);
            //int e9 = graphGTS.AddEdge(v1, v6, false, 11);
            int e10 = graphGTS.AddEdge(v1, v2, true, 11);

            int e2 = graphGTS.AddEdge(v2, v3, true, 15);

            int e3 = graphGTS.AddEdge(v3, v4, false, 20);
            int e4 = graphGTS.AddEdge(v4, v5, false, 25);
            int e5 = graphGTS.AddEdge(v5, v1, false, 30);
            int e13 = graphGTS.AddEdge(v1, v4, false, 30);
            int e6 = graphGTS.AddLoop(v6, false);
            int e11 = graphGTS.AddLoop(v6, true);

            int e20 = graphGTS.AddEdge(v3, v7, true, 5);
            //int e21 = graphGTS.AddEdge(v5, v7, true, 5);

            graphGTS.RemoveEdge(e3);

            Console.WriteLine($"Non-Loop: {graphGTS.EdgeCountBetweenVertices(v1, v2)}");
            Console.WriteLine($"Loop: {graphGTS.EdgeCountLoopVertex(v6)}");

            Console.WriteLine($"Components: {graphGTS.ComponentCount}");


            (bool, (List<VertexGTS<string>>, List<VertexGTS<string>>)?) partiteSets = graphGTS.IsBipartite();

            Console.WriteLine($"Bi-Partite?: {partiteSets.Item1}");

            foreach (EdgeGTS<string> edge in graphGTS.GetBridges())
            {
                Console.WriteLine($"BridgeID: {edge.EdgeID}");
            }



            Print2DArray(graphGTS.GetAdjacenyMatrix().Item2);

            /*
            int v1 = graphGTS.AddVertex();
            int v2 = graphGTS.AddVertex();
            int v3 = graphGTS.AddVertex();
            int v4 = graphGTS.AddVertex();
            int v5 = graphGTS.AddVertex();
            int v6 = graphGTS.AddVertex();

            int e1 = graphGTS.AddEdge(v1, v2, true, 5);
            int e11 = graphGTS.AddEdge(v2, v1, true, 5);

            int e2 = graphGTS.AddEdge(v1, v3, true, 6);
            int e12 = graphGTS.AddEdge(v3, v1, true, 6);

            int e3 = graphGTS.AddEdge(v1, v5, true, 20);
            int e13 = graphGTS.AddEdge(v5, v1, true, 20);

            int e4 = graphGTS.AddEdge(v3, v5, true, 2);
            int e14 = graphGTS.AddEdge(v5, v3, true, 2);

            int e5 = graphGTS.AddEdge(v3, v4, true, 3);
            int e15 = graphGTS.AddEdge(v4, v3, true, 3);

            int e6 = graphGTS.AddEdge(v5, v6, false, 15);

            Console.WriteLine("Vertex, FromVertex, Distance");
            foreach (KeyValuePair<VertexGTS<string>, (VertexGTS<string>?, float)> vertexShortest in graphGTS.GetShortestPaths(v1))
            {
                Console.WriteLine($"[{vertexShortest.Key.VertexID}, {vertexShortest.Value.Item1?.VertexID}, {vertexShortest.Value.Item2}]");
            }
            */

            /*
            int v1 = graphGTS.AddVertex();
            int v2 = graphGTS.AddVertex();

            int e1 = graphGTS.AddEdge(v2, v1, true, 5);

            foreach (EdgeGTS<string> edge in graphGTS.GetBridgesTarjan())
            {
                Console.WriteLine($"BridgeID: {edge.EdgeID}");
            }
            */
        }

        public static void CreateBiPartiteGraph<Type>(AbstractGraphGTS<Type> graph)
        {
            int v1 = graph.AddVertex();
            int v2 = graph.AddVertex();
            int v3 = graph.AddVertex();
            int v4 = graph.AddVertex();
            int v5 = graph.AddVertex();
            int v6 = graph.AddVertex();

            // --- CASE 1: Basic Bipartite Graph ---
            int e1 = graph.AddEdge(v1, v4, false, 5);
            int e2 = graph.AddEdge(v2, v5, false, 7);
            int e3 = graph.AddEdge(v3, v6, false, 3);

            // --- CASE 2: Disconnected Bipartite Components ---
            int v7 = graph.AddVertex();
            int v8 = graph.AddVertex();
            int v9 = graph.AddVertex();
            int v10 = graph.AddVertex();

            int e4 = graph.AddEdge(v7, v9, false, 4);
            int e5 = graph.AddEdge(v8, v10, false, 6);

            // --- CASE 3: Bipartite Graph with Weighted Edges ---
            int e6 = graph.AddEdge(v1, v5, false, 12);
            int e7 = graph.AddEdge(v2, v6, false, 8);

            // --- CASE 4: Directed Bipartite Graph ---
            int e8 = graph.AddEdge(v3, v4, true, 10);
            //int e9 = graph.AddEdge(v5, v6, true, 9);

            // --- CASE 5: Tree Structure (Always Bipartite) ---
            int v11 = graph.AddVertex();
            int v12 = graph.AddVertex();
            int v13 = graph.AddVertex();

            int e10 = graph.AddEdge(v11, v12, false, 3);
            int e11 = graph.AddEdge(v12, v13, false, 6);
        }

        public static void Print2DArray(List<List<int>> array2D)
        {
            for (int i = 0; i < array2D.Count; i++)
            {
                for (int j = 0; j < array2D[i].Count; j++)
                {
                    Console.Write($" {array2D[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
