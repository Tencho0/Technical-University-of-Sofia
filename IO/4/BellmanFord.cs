using System;
using System.Collections.Generic;

class BellmanFord
{
    static (double[] distance, int?[] pred)? BellmanFordSolve(
        Dictionary<int, List<(int neighbour, int cost)>> graph, int source)
    {
        int n = graph.Count;
        double[] distance = new double[n + 1];
        int?[] pred = new int?[n + 1];

        for (int i = 0; i <= n; i++)
        {
            distance[i] = double.PositiveInfinity;
            pred[i] = null;
        }
        distance[source] = 0;

        for (int _ = 0; _ < n; _++)
        {
            for (int node = 1; node <= n; node++)
            {
                foreach (var (neighbour, cost) in graph[node])
                {
                    if (distance[node] != double.PositiveInfinity && distance[node] + cost < distance[neighbour])
                    {
                        distance[neighbour] = distance[node] + cost;
                        pred[neighbour] = node;
                    }
                }
            }
        }

        for (int node = 1; node <= n; node++)
        {
            foreach (var (neighbour, cost) in graph[node])
            {
                if (distance[node] != double.PositiveInfinity && distance[node] + cost < distance[neighbour])
                {
                    Console.WriteLine("Графът съдържа цикъл с отрицателна тегловна сума");
                    return null;
                }
            }
        }

        return (distance, pred);
    }

    static void PrintPath(int?[] pred, int source, int target)
    {
        List<int> path = new List<int>();
        int? current = target;
        while (current != null)
        {
            path.Add(current.Value);
            current = pred[current.Value];
        }
        path.Reverse();
        Console.WriteLine(string.Join(" -> ", path));
    }

    static void Main()
    {
        var graph = new Dictionary<int, List<(int neighbour, int cost)>>
        {
            {1, new List<(int, int)> {(2, 2), (3, 2), (4, 5)}},
            {2, new List<(int, int)> {(5, 8), (6, 12)}},
            {3, new List<(int, int)> {(4, 3), (5, 6)}},
            {4, new List<(int, int)> {(5, 10), (7, 15)}},
            {5, new List<(int, int)> {(6, 6), (7, 8), (8, 7)}},
            {6, new List<(int, int)> {(8, 4)}},
            {7, new List<(int, int)> {(8, 5)}},
            {8, new List<(int, int)> {}}
        };

        int source = 1;
        int target = 8;

        var result = BellmanFordSolve(graph, source);
        if (result != null)
        {
            var (distance, pred) = result.Value;
            Console.WriteLine("Дължината на най-късият път е: " + distance[target]);
            Console.Write("Най-късият път е: ");
            PrintPath(pred, source, target);
        }
    }
}
