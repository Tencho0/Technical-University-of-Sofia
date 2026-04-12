using System;
using System.Collections.Generic;

class Knapsack
{
    static (int maxValue, Dictionary<int, int> itemCounts) KnapsackSolve(
        int W, int[] weights, int[] values, int n, bool multipleItemsAllowed)
    {
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
            dp[i] = new int[W + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int w = 1; w <= W; w++)
            {
                if (weights[i - 1] <= w)
                {
                    if (multipleItemsAllowed)
                        dp[i][w] = Math.Max(dp[i - 1][w], values[i - 1] + dp[i][w - weights[i - 1]]);
                    else
                        dp[i][w] = Math.Max(dp[i - 1][w], values[i - 1] + dp[i - 1][w - weights[i - 1]]);
                }
                else
                {
                    dp[i][w] = dp[i - 1][w];
                }
            }
        }

        int res = dp[n][W];
        int ww = W;
        List<int> itemsSelected = new List<int>();

        int ii = n;
        while (ii > 0 && res > 0)
        {
            if (multipleItemsAllowed)
            {
                while (ii > 0 && ww >= weights[ii - 1] && dp[ii][ww] == dp[ii][ww - weights[ii - 1]] + values[ii - 1])
                {
                    itemsSelected.Add(ii);
                    ww -= weights[ii - 1];
                    res -= values[ii - 1];
                }
                ii--;
            }
            else
            {
                if (dp[ii][ww] != dp[ii - 1][ww])
                {
                    itemsSelected.Add(ii);
                    res -= values[ii - 1];
                    ww -= weights[ii - 1];
                }
                ii--;
            }
        }

        Dictionary<int, int> itemCounts = new Dictionary<int, int>();
        foreach (int item in itemsSelected)
        {
            if (itemCounts.ContainsKey(item))
                itemCounts[item]++;
            else
                itemCounts[item] = 1;
        }

        return (dp[n][W], itemCounts);
    }

    static void Main()
    {
        int W = 600;
        int[] weights = { 150, 160, 220, 120, 80 };
        int[] values = { 45, 50, 70, 40, 30 };
        int n = 5;
        bool multipleItemAllowed = true;

        var (maxCosts, itemInKnapsack) = KnapsackSolve(W, weights, values, n, multipleItemAllowed);

        Console.WriteLine("Максималната цена на раницата е: " + maxCosts);
        Console.Write("Продуктите и техният брой, които се включват в раницата са: ");
        foreach (var kvp in itemInKnapsack)
            Console.Write($"Продукт {kvp.Key}: {kvp.Value} бр.  ");
        Console.WriteLine();
    }
}
