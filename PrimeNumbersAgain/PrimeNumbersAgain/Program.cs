using System;
using System.Diagnostics;

namespace PrimeNumbersAgain
{
    class Program
    {
        public static int[] primeArr = new int[2000001];
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {
            if (n == 1) { return 2; }
            primeArr[0] = 1;
            primeArr[1] = 2;

            int num = 3;
            int count = 1;
            while (true)
            {
                
                if (IsPrime(num))
                {
                    count++;
                    primeArr[count] = num;
                }

                if (count == n)
                {
                    return num;
                }
                num += 2;

            }
        }



        static bool IsPrime(int num)
        {
            for (var a = 1; primeArr[a] <= Math.Sqrt(num); a++)
            {
                if (num % primeArr[a] == 0)
                {
                    return false;
                }

            }
            return true;
        }



        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 3 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}
