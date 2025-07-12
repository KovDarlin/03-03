
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Program
{
    static bool isPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0)
                return false;
        return true;
    }


    static bool isFibonachi(int n)
    {
        return isSquare(5 * n * n + 4) || isSquare(5 * n * n - 4);
    }

    static bool isSquare(int n)
    {
        int root = (int)Math.Sqrt(n);
        return root * root == n;
    }

    static void Main()
    {
        string mainFile = "main.txt";
        string fibFile = "fibonachi.txt";

        Random rand = new Random();
        List<int> num = new List<int>();
        for(int i =0; i < 100; i++)
        {
            num.Add(rand.Next(1, 1001));
        }

        List<int> main = num.Where(isPrime).ToList();
        List<int> fibonachi = num.Where(isFibonachi).ToList();

        File.WriteAllLines(mainFile, main.Select(x => x.ToString()));
        File.WriteAllLines(fibFile,fibonachi.Select(x => x.ToString()));

        Console.WriteLine($"Total number of numbers: {num.Count}");
        Console.WriteLine($"Primes numbers: {main.Count}");
        Console.WriteLine($"Fibonaccis numbers: {fibonachi.Count}");

        var parting = main.Intersect(fibonachi).ToList();
        Console.WriteLine($"Numbers that are both prime and Fibonacci:{parting.Count}");

        if (parting.Count > 0)
        {
            Console.WriteLine("Numbers: " + string.Join(" ", parting));
        }
    }

    
}