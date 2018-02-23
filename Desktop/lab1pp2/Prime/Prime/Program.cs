using System;

namespace Lab1
{
    class Program
    {
        public static bool isPrime(int a)
        {
            if (a == 1) return false;
            for (int i = 2; i <= Math.Sqrt(a); i++)
                if (a % i == 0) return false;
            return true;
        }
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] numbers = line.Split(' ');
            for (int i = 0; i < numbers.Length; i++)
                if (isPrime(int.Parse(numbers[i])))
                    Console.WriteLine(numbers[i]);
        }
    }
}