namespace ExamPrep01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();

            int[] resultElements = ReadArrayFromFile(fileName);
            foreach (var element in resultElements)
                Console.Write($"{element} ");
            Console.WriteLine();

            Console.WriteLine(IsSorted(resultElements));

            Console.WriteLine(CountTriplets(resultElements));
        }

        private static int[] ReadArrayFromFile(string fileName)
        {
            string result = File.ReadAllText(fileName);

            int[] resultArray = result
                .Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return resultArray;
        }

        private static bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static int CountTriplets(int[] array)
        {
            int counter = 0;
            for (int i = 0; i < array.Length - 2; i++)
            {
                for (int k = i + 1; k < array.Length - 1; k++)
                {
                    for (int j = k + 1; j < array.Length; j++)
                    {
                        if (array[i] == array[k] && array[k] == array[j])
                        {
                            Console.WriteLine($"На индекси {i}, {k}, {j} се намира елемент {array[i]}");
                            counter++;
                        }
                    }
                }
            }

            return counter;
        }
    }
}