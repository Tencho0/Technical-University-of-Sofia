namespace Homework01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            int iterativeResult = FindNthTermIterative(n);
            Console.WriteLine($"A{n} = {iterativeResult}");

            int recursiveResult = FindNthTermRecursive(n);
            Console.WriteLine($"A{n} = {recursiveResult}");
        }

        // Task 01
        static int FindNthTermIterative(int n)
        {
            if (n == 1)
                return 2;
            if (n == 2)
                return 4;
            if (n == 3)
                return 6;

            int a1 = 2;
            int a2 = 4;
            int a3 = 6;
            int result = 0;

            for (int i = 4; i <= n; i++)
            {
                result = 3 * a1 + 4 * a2 - 7 * a3;
                a1 = a2;
                a2 = a3;
                a3 = result;
            }

            return result;
        }


        // Task 02
        static int FindNthTermRecursive(int n)
        {
            if (n == 1)
                return 2;
            if (n == 2)
                return 4;
            if (n == 3)
                return 6;

            return 3 * FindNthTermRecursive(n - 3) + 4 * FindNthTermRecursive(n - 2) - 7 * FindNthTermRecursive(n - 1);
        }
    }
}