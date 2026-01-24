namespace Homework05
{
    using System;
    using System.IO;

    class MatrixApplication
    {
        static void Main()
        {
            Console.WriteLine("Enter the size of the matrix (N x N):");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            InitializeMatrix(matrix, n);

            Console.WriteLine("Enter the file path for matrix initialization:");
            string filePath = Console.ReadLine();
            InitializeMatrixFromFile(matrix, filePath, n);

            PrintMatrix(matrix, n);

            (int evenSum, int oddSum) = CalculateEvenOddSums(matrix, n);
            Console.WriteLine($"Sum of Even Elements: {evenSum}");
            Console.WriteLine($"Sum of Odd Elements: {oddSum}");

            (int evenRowSum, int oddColumnSum) = CalculateRowColumnSums(matrix, n);
            Console.WriteLine($"Sum of Elements in Even Rows: {evenRowSum}");
            Console.WriteLine($"Sum of Elements in Odd Columns: {oddColumnSum}");
        }

        static void InitializeMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = -1;
        }

        static void InitializeMatrixFromFile(int[,] matrix, string filePath, int n)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');
                    int row = int.Parse(parts[0]);
                    int col = int.Parse(parts[1]);
                    int value = int.Parse(parts[2]);

                    if (row < n && col < n)
                    {
                        matrix[row, col] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static (int, int) CalculateEvenOddSums(int[,] matrix, int n)
        {
            int evenSum = 0, oddSum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] % 2 == 0) evenSum += matrix[i, j];
                    else oddSum += matrix[i, j];
                }
            return (evenSum, oddSum);
        }

        static (int, int) CalculateRowColumnSums(int[,] matrix, int n)
        {
            int evenRowSum = 0, oddColumnSum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i % 2 == 0) evenRowSum += matrix[i, j];
                    if (j % 2 != 0) oddColumnSum += matrix[i, j];
                }
            return (evenRowSum, oddColumnSum);
        }
    }

}