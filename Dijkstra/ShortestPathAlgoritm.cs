namespace Västtrafik2._1
{
    public static class ShortestPathAlgoritm
    {
        // A utility function to find the
        // node with minimum distance
        // value, from the set of nodes
        // not yet included in shortest
        // path tree
        public static int V = 10;

        public static int MinDistance(int[] dist, bool[] sptSet) // ordo = O(n)
        {
            // Initialize min value.
            int min = int.MaxValue;
            var minIndex = 0;

            for (int i = 0; i < V; i++)
                if (sptSet[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    minIndex = i;
                }

            return minIndex;
        }

        // Function that implements Dijkstra's
        // single source shortest path algorithm
        // in a 10 x 10 graph.
        public static int dijkstra(int[,] graph, int startNode, int stopNode)
        {
            int[] dist = new int[V];
            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = RecursionMethod(V); // Uses a recursive method to make sure the array indexes to be higher than any distance possible.
                sptSet[i] = false;
            }

            // Sets distance to it self to 0
            dist[startNode] = 0;

            // Finds the shortest path for all nodes.
            for (int count = 0; count < V - 1; count++) // ordo = O(n^2+n)
            {
                // Pick the minimum distance node
                // from the set of nodes not processed.
                // u is always equal to startNode in first iteration
                int u = MinDistance(dist, sptSet);

                sptSet[u] = true;

                // Update dist index value of the closest
                // node of the picked nodes.
                for (int v = 0; v < V; v++)

                    // Sets new value to dist[v] if its not
                    // already in the shortest path tree set.
                    // There is an edge from u
                    // to v, and total time of path
                    // from startNode to v through u is smaller
                    // than current value of dist[v]
                    if (!sptSet[v] && graph[u, v] != 0 &&
                        dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }
            return dist[stopNode];
        }

        // graph
        public static int[,] TimeTable()
        {
            //     A  B  C  D  E  F  G  H  I  J
            return new int[,] {     { 0, 4, 7, 0, 7, 0, 0, 0, 0, 0 },
                                    { 4, 0, 3, 12, 0, 0, 0, 5, 0, 0 },
                                    { 7, 3, 0, 0, 0, 0, 4, 0, 12, 0 },
                                    { 0, 12, 0, 0, 0, 0, 0, 7, 3, 0 },
                                    { 7, 0, 0, 0, 0, 3, 5, 0, 0, 0 },
                                    { 0, 0, 0, 0, 3, 0, 5, 0, 0, 0 },
                                    { 0, 0, 4, 0, 5, 5, 0, 8, 13, 8 },
                                    { 0, 5, 0, 7, 0, 0, 8, 0, 0, 9 },
                                    { 0, 0, 12, 3, 0, 0, 13, 0, 0, 7 },
                                    { 0, 0, 0, 0, 0, 0, 8, 9, 7, 0 } };
        }

        // recursion method, factors the numbers and returns it.
        private static int RecursionMethod(int number)
        {
            if (number <= 0)
            {
                return 1;
            }
            return number * RecursionMethod(number - 1);
        }
    }
}
