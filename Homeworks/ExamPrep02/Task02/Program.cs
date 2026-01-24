namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public static double Iterative(int n)
        {
            if (n == 1) return 1.0 / 3;
            if (n == 2) return 3;
            if (n == 3) return 4;
            if (n == 4) return 5;

            double n1 = 1.0 / 3, n2 = 3, n3 = 4, n4 = 5, ni = 0;

            for (int i = 5; i <= n; i++)
            {
                ni = 2 * n4 + 4 * n2 - n1;
                n1 = n2;
                n2 = n3;
                n3 = n4;
                n4 = ni;
            }

            return ni;
        }

        public static double Recursive(int n)
        {
            if (n == 1) return 1.0 / 3;
            if (n == 2) return 3;
            if (n == 3) return 4;
            if (n == 4) return 5;

            return 2 * Recursive(n - 1) + 4 * Recursive(n - 3) - Recursive(n - 4);
        }

    }
}