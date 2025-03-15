using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using GTS_GraphEngine;

namespace Testing_GraphEngine
{
    internal class MainMain
    {
        static void Main(string[] args) {
        
           GraphGTSWeighted<string> graphGTS = new GraphGTSWeighted<string>();

            int v1 = graphGTS.AddVertex();
            int v2 = graphGTS.AddVertex();
            int v3 = graphGTS.AddVertex();
            int v4 = graphGTS.AddVertex();
            int v5 = graphGTS.AddVertex();
            int v6 = graphGTS.AddVertex();

            int e1 = graphGTS.AddEdge(v1, v2, false, 11);
            int e7 = graphGTS.AddEdge(v1, v2, true, 11);
            int e8 = graphGTS.AddEdge(v2, v1, true, 11);
            int e9 = graphGTS.AddEdge(v1, v6, false, 11);
            int e10 = graphGTS.AddEdge(v1, v2, true, 11);

            int e2 = graphGTS.AddEdge(v2, v3, false, 15);
            int e3 = graphGTS.AddEdge(v3, v4, false, 20);
            int e4 = graphGTS.AddEdge(v4, v5, false, 25);
            int e5 = graphGTS.AddEdge(v5, v1, false, 30);
            int e6 = graphGTS.AddLoop(v6, false);
            int e11 = graphGTS.AddLoop(v6, true);

            graphGTS.RemoveEdge(e3);

            Console.WriteLine($"Non-Loop: {graphGTS.EdgeCountBetweenVertices(v1, v2)}");
            Console.WriteLine($"Loop: {graphGTS.EdgeCountLoopVertex(v6)}");

            int i = 0;
        }
    }
}
