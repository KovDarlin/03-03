using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter the path to the text file: ");
        string textFilePath = Console.ReadLine();

        Console.Write("Enter the path to the file with the words to moderate: ");
        string blacklistFilePath = Console.ReadLine();

        if (!File.Exists(textFilePath) || !File.Exists(blacklistFilePath))
        {
            Console.WriteLine("I can`t find this files!");
            return;
        }

        var blacklistWords = new HashSet<string>(
            File.ReadAllText(blacklistFilePath)
                .Split(new[] { ' ', ',', '.', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries),
            StringComparer.OrdinalIgnoreCase
        );

        int totalReplacements = 0;
        int linesWithReplacements = 0;
        var outputLines = new List<string>();

        foreach (string line in File.ReadLines(textFilePath))
        {
            bool lineChanged = false;
            string modifiedLine = line;

            foreach (var word in blacklistWords)
            {
                string pattern = $@"\b{Regex.Escape(word)}\b";
                var matches = Regex.Matches(modifiedLine, pattern, RegexOptions.IgnoreCase);

                if (matches.Count > 0)
                {
                    lineChanged = true;
                    totalReplacements += matches.Count;
                    string replacement = new string('*', word.Length);
                    modifiedLine = Regex.Replace(modifiedLine, pattern, replacement, RegexOptions.IgnoreCase);
                }
            }

            if (lineChanged) linesWithReplacements++;
            outputLines.Add(modifiedLine);
        }

        string outputPath = "moderated.txt";
        File.WriteAllLines(outputPath, outputLines);

        Console.WriteLine($"Blacklisted words: {blacklistWords.Count}");
        Console.WriteLine($"Total number of substitutions: {totalReplacements}");
        Console.WriteLine($"Lines with moderated words: {linesWithReplacements}");
        Console.WriteLine($"The result is saved in a file: {outputPath}");
    }
}
