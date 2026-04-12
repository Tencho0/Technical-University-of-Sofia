using System;
using System.Collections.Generic;

class Bellman
{
    static Dictionary<(int, int), int> returns = new Dictionary<(int, int), int>
    {
        {(1, 0), 0},
        {(1, 1), 2},
        {(1, 3), 5},
        {(2, 0), 0},
        {(2, 2), 3},
        {(2, 3), 5},
        {(2, 4), 6},
        {(3, 0), 0},
        {(3, 1), 2},
        {(3, 2), 4},
        {(3, 4), 6}
    };

    static int R(int i, int c)
    {
        while (c >= 0)
        {
            if (returns.ContainsKey((i, c)))
                return returns[(i, c)];
            c--;
        }
        return 0;
    }

    static (int maxProfit, List<(int opportunity, int invested)> plan) BellmanSolve(
        int investmentOpportunities, int totalCapital)
    {
        int[][] dp = new int[investmentOpportunities + 1][];
        for (int i = 0; i <= investmentOpportunities; i++)
            dp[i] = new int[totalCapital + 1];

        for (int j = 1; j <= investmentOpportunities; j++)
        {
            for (int y = 0; y <= totalCapital; y++)
            {
                dp[j][y] = dp[j - 1][y];
                for (int c = 0; c <= y; c++)
                {
                    dp[j][y] = Math.Max(dp[j][y], R(j - 1, c) + dp[j - 1][y - c]);
                }
            }
        }

        List<(int opportunity, int invested)> result = new List<(int, int)>();
        int remainingCapital = totalCapital;

        for (int j = investmentOpportunities; j >= 0; j--)
        {
            if (j == 0 || dp[j][remainingCapital] == dp[j - 1][remainingCapital])
                continue;

            int invested = -1;
            for (int c = 0; c <= remainingCapital; c++)
            {
                if (dp[j][remainingCapital] == R(j - 1, c) + dp[j - 1][remainingCapital - c])
                {
                    invested = c;
                    break;
                }
            }

            if (invested != -1)
            {
                result.Add((j - 1, invested));
                remainingCapital -= invested;
            }
        }

        result.Reverse();
        return (dp[investmentOpportunities][totalCapital], result);
    }

    static void Main()
    {
        int totalCapital = 5;
        int investmentOpportunities = 4;

        var (maxProfit, investmentPlan) = BellmanSolve(investmentOpportunities, totalCapital);

        Console.WriteLine($"Максималната възвращаемост: {maxProfit}");
        Console.Write("План за инвестиция: ");
        foreach (var (opportunity, invested) in investmentPlan)
            Console.Write($"(Предприятие {opportunity + 1}, Капитал {invested}) ");
        Console.WriteLine();
    }
}
