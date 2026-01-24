namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private static double Iterrative(int n)
        {
            if (n == 1) return 2;
            if (n == 2) return 3;
            if (n == 3) return 4;
            if (n == 4) return 5;

            double n1 = 2;
            double n2 = 3;
            double n3 = 4;
            double n4 = 5;
            double x = 0;

            for (int i = 5; i <= n; i++)
            {
                x = n4 * n4 * n4 + 2 * n2 - 3 * n1;
                n1 = n2;
                n2 = n3;
                n3 = n4;
                n4 = x;
            }

            return x;
        }

        private static double Recursive(int n)
        {
            if (n == 1) return 2;
            if (n == 2) return 3;
            if (n == 3) return 4;
            if (n == 4) return 5;

            return Recursive(n - 4) * Recursive(n - 4) * Recursive(n - 4) + 2 * Recursive(n - 2) - 3 * Recursive(n - 1);
        }
    }
}