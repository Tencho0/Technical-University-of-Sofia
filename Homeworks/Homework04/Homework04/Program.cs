namespace Homework04
{
    using System;
    using System.IO;

    class FileStatistics
    {
        public static void Main()
        {
            Console.WriteLine("Enter the file path:");
            string fileName = Console.ReadLine();

            int dotCount = 0, commaCount = 0, integerCount = 0;
            bool inInteger = false;

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    int ch;
                    while ((ch = reader.Read()) != -1)
                    {
                        char currentChar = (char)ch;

                        if (currentChar == '.')
                            dotCount++;
                        else if (currentChar == ',')
                            commaCount++;

                        if (char.IsDigit(currentChar))
                        {
                            if (!inInteger)
                            {
                                inInteger = true;
                                integerCount++;
                            }
                        }
                        else
                        {
                            inInteger = false;
                        }
                    }
                }

                Console.WriteLine($"Periods: {dotCount}");
                Console.WriteLine($"Commas: {commaCount}");
                Console.WriteLine($"Integers: {integerCount}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}