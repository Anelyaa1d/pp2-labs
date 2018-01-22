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
            for (int i = 0; i < args.Length; i++)
                if (isPrime(int.Parse(args[i])))
                    Console.WriteLine(args[i]);
        }
    }
}
