using System;

class Prim
{
    const int MAXN = 150;
    const int MAX_VALUE = 10000;

    static int n = 9;

    static int[][] A = new int[][]
    {
        new int[] {0, 1, 0, 2, 0, 0, 0, 0, 0},
        new int[] {1, 0, 3, 0, 13, 0, 0, 0, 0},
        new int[] {0, 3, 0, 4, 0, 3, 0, 0, 0},
        new int[] {2, 0, 4, 0, 0, 16, 14, 0, 0},
        new int[] {0, 13, 0, 0, 0, 12, 0, 1, 13},
        new int[] {0, 0, 3, 16, 12, 0, 1, 0, 1},
        new int[] {0, 0, 0, 14, 0, 1, 0, 0, 0},
        new int[] {0, 0, 0, 0, 1, 0, 0, 0, 0},
        new int[] {0, 0, 0, 0, 13, 1, 0, 0, 0}
    };

    static int[] used = new int[MAXN];
    static int[] prev = new int[MAXN];
    static int[] T = new int[MAXN];

    static void PrimMST()
    {
        int MST = 0;

        for (int i = 0; i < n; i++)
        {
            used[i] = 0;
            prev[i] = 0;
        }

        used[0] = 1;

        for (int i = 0; i < n; i++)
        {
            T[i] = A[0][i] != 0 ? A[0][i] : MAX_VALUE;
        }

        for (int _ = 0; _ < n - 1; _++)
        {
            int minDist = MAX_VALUE;
            int j = -1;

            for (int i = 0; i < n; i++)
            {
                if (used[i] == 0 && T[i] < minDist)
                {
                    minDist = T[i];
                    j = i;
                }
            }

            used[j] = 1;
            Console.Write($"({prev[j] + 1},{j + 1}) ");
            MST += minDist;

            for (int i = 0; i < n; i++)
            {
                if (used[i] == 0 && A[j][i] != 0 && T[i] > A[j][i])
                {
                    T[i] = A[j][i];
                    prev[i] = j;
                }
            }
        }

        Console.WriteLine($"\nЦената на минималното покриващо дърво е {MST}.");
    }

    static void Main()
    {
        PrimMST();
    }
}
