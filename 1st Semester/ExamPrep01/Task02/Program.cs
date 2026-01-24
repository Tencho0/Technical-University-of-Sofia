namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(Iterative(input));
            Console.WriteLine(Recursive(input));
        }

        private static int Iterative(int x)
        {
            int count = 0;
            while (x != 1)
            {
                x = Func(x);
                count++;
            }

            return count;
        }

        private static int Recursive(int x)
        {
            if (x == 1)
            {
                return 0;
            }

            if (x % 2 == 0)
            {
                return Recursive(x / 2) + 1;
            }

            return Recursive(x * 3 + 1) + 1;
        }

        private static int Func(int x)
        {
            if (x % 2 == 0)
            {
                return x / 2;
            }

            return x * 3 + 1;
        }
    }
}