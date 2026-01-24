using System.Runtime.InteropServices;

namespace Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();
        }

        private static int[] ReadArrayFromFile(string fileName)
        {
            var fileData = File.ReadAllText(fileName)
                .Split('|');

            var arratToReturn = new int[fileData.Length];
            for (int i = 0; i < fileData.Length; i++)
            {
                arratToReturn[i] = int.Parse(fileData[i]);
            }

            return arratToReturn;
        }

        private static int LargestNegative(int[] array)
        {
            var largestElement = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    largestElement = array[i];
                }
            }

            return largestElement;
        }

        public static int CountPowersOf2(int[] arr)
        {
            int count = 0;
            foreach (var number in arr)
            {
                if (number > 0 && (number & (number - 1)) == 0)
                {
                    count++;
                }
            }
            return count;
        }
        private static bool IsPowerOfTwo(int number)
        {
            if (number <= 0)
                return false;
            
            while (number % 2 == 0)
            {
                number /= 2;
            }
            
            return number == 1;
        }
        
        public static int CountPowersOf2Snc(int[] arr)
        {
            int count = 0;
            foreach (int number in arr)
            {
                if (IsPowerOfTwo(number))
                {
                    count++;
                }
            }
            return count;
        }

    }
}