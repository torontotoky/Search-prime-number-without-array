using System;
using System.Collections.Generic;
using System.Linq;

namespace Search_prime_number_without_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int searchLine = inputSearchLine(); // 1 - прямоеб 0 - обратное
            List<int> PrimeNumbers = new List<int>();
            List<string> pointOfSearch = new List<string>(getValidValues());
            PrimeNumbers = searchPrimeNumbers(pointOfSearch, searchLine);
            OutputPrime(PrimeNumbers);
            Console.ReadKey();
        }
        static List<int> searchPrimeNumbers(List<string> pointsOfSearch, int searchLine)
        {
            int startSearch = Convert.ToInt32(pointsOfSearch[0].Trim());
            int endSearch = Convert.ToInt32(pointsOfSearch[pointsOfSearch.Count - 1].Trim());
            int countPrimeNumbers = 0;
            bool flag = false;
            List<int> primeNumbers = new List<int>();
            if (pointsOfSearch.Count == 1)
            {
                if (searchLine == 1)
                {
                    while (countPrimeNumbers != 3)
                    {
                        if (isPrime(++startSearch))
                        {
                            primeNumbers.Add(startSearch);
                            countPrimeNumbers++;
                        }
                    }
                }
                else
                {
                    while (countPrimeNumbers != 3)
                    {
                        if (isPrime(--startSearch))
                        {
                            primeNumbers.Add(startSearch);
                            countPrimeNumbers++;
                        }
                        if (startSearch == 0)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                if (searchLine == 1)
                {
                    while (countPrimeNumbers != 3)
                    {
                        if (isPrime(++startSearch))
                        {
                            primeNumbers.Add(startSearch);
                            countPrimeNumbers++;
                        }
                    }
                }
                else
                {
                    while (countPrimeNumbers != 3)
                    {
                        if (isPrime(--endSearch))
                        {
                            primeNumbers.Add(endSearch);
                            countPrimeNumbers++;
                        }
                        if (endSearch == 0)
                        {
                            break;
                        }
                    }
                }
            }
            return primeNumbers;
        }
        static int inputSearchLine()
        {
            int searchLine;
            string input;
            do
            {
                Console.WriteLine("\nнаправление поиска");
                input = Console.ReadLine();
                while (!Int32.TryParse(input, out searchLine))
                {
                    Console.WriteLine("Введите целое число");
                    input = Console.ReadLine();
                }
            }
            while (searchLine != 0 && searchLine != 1);
            return searchLine;
        }

        static List<string> getValidValues()
        {
            string input;
            List<string> validValue = new List<string>();
            do
            {
                Console.WriteLine("Введите диапазон поиска или точку начала поиска");
                input = Console.ReadLine();
            }
            while (!checkValues(input));
            validValue = input.Split(',').ToList();
            for (int i = 0; i < validValue.Count; i++)
            {
                validValue[i] = validValue[i].Trim();
            }
            validValue.Sort();
            return validValue;
        }

        static bool checkValues(string input)
        {
            int num;
            List<string> validValues = new List<string>();
            input.Replace(" ", ",");
            validValues = input.Split(',').ToList();
            if (input == null)
            {
                return false;
            }
            else if (validValues.Count > 2)
            {
                return false;
            }
            for (int i = 0; i < validValues.Count; i++)
            {
                if (!int.TryParse(validValues[i].Trim(), out num))
                {
                    return false;
                }
            }
            return true;
        }

        static bool isPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }
            if (number == 0)
            {
                return false;
            }
            for (int i = 2; i <= (int)number / 2; i++)
                if (number % i == 0)
                {
                    return false;
                }
            return true;
        }

        static void OutputPrime(List<int> numbers)
        {
            if (numbers.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
            else if (numbers.Count < 3 && numbers.Count != 0)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    Console.WriteLine(numbers[i]);
                }
                Console.WriteLine("Найдено < 3");
            }
            else if (numbers.Count == 0)
            {
                Console.WriteLine("Ничего не нашли");
            }
        }
    }
}
