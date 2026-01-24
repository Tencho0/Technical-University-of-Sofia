using System;

class Program
{
    static void Main()
    {
        int[,] matrix = new int[3, 3];

        Console.WriteLine("Enter the elements of the matrix (row-wise):");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Enter element at position ({i + 1}, {j + 1}): ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    matrix[i, j] = value;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    j--;
                }
            }
        }

        int evenSumOddRows = 0;
        for (int i = 0; i < 3; i += 2)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrix[i, j] % 2 == 0)
                {
                    evenSumOddRows += matrix[i, j];
                }
            }
        }

        int oddSumEvenCols = 0;
        for (int i = 1; i < 3; i += 2)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrix[i, j] % 2 != 0)
                {
                    oddSumEvenCols += matrix[i, j];
                }
            }
        }

        Console.WriteLine($"Sum of even-valued elements in odd-numbered rows: {evenSumOddRows}");
        Console.WriteLine($"Sum of odd-valued elements in even-numbered columns: {oddSumEvenCols}");
    }
}