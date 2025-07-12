using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter path to file: ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("I can`t find file!");
            return;
        }

        var text = File.ReadAllText(filePath);
        var numbers = text
            .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => int.Parse(s))
            .ToList();

        var positives = numbers.Where(n => n > 0).ToList();
        var negatives = numbers.Where(n => n < 0).ToList();
        var twoDigits = numbers.Where(n => Math.Abs(n) >= 10 && Math.Abs(n) <= 99).ToList();
        var fiveDigits = numbers.Where(n => Math.Abs(n) >= 10000 && Math.Abs(n) <= 99999).ToList();

        File.WriteAllLines("positive.txt", positives.Select(n => n.ToString()));
        File.WriteAllLines("negative.txt", negatives.Select(n => n.ToString()));
        File.WriteAllLines("two_digit.txt", twoDigits.Select(n => n.ToString()));
        File.WriteAllLines("five_digit.txt", fiveDigits.Select(n => n.ToString()));

        Console.WriteLine($"All numbers: {numbers.Count}");
        Console.WriteLine($"Positive: {positives.Count}");
        Console.WriteLine($"Negative: {negatives.Count}");
        Console.WriteLine($"Two digit: {twoDigits.Count}");
        Console.WriteLine($"Five digit: {fiveDigits.Count}");
    }
}
