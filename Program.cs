class Program
{


    static int CountOccurrence(string line, string word)
    {
        int count = 0;
        int index = 0;
        while ((index = line.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += word.Length;
        }
        return count;
    }
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine($"File {inputFile} does not exist");
            return;
        }

        Console.WriteLine("Enter word to search: ");
        string searchWord = Console.ReadLine();

        Console.WriteLine("Enter word to update: ");
        string updateWord = Console.ReadLine();

        int totalUpdates = 0;
        int linesWithMatch = 0;

        var outputLines = new List<string>();
        foreach (string line in File.ReadLines(inputFile))
        {
            int countInLine = CountOccurrence(line, searchWord);
            if (countInLine > 0)
            {
                linesWithMatch++;
                totalUpdates += countInLine;
            }

            string replacedLine = line.Replace(searchWord, updateWord);
            outputLines.Add(replacedLine);
        }
        File.WriteAllLines(outputFile, outputLines);

        Console.WriteLine($"Word to search: \"{searchWord}\"");
        Console.WriteLine($"Word to update: \"{updateWord}\"");
        Console.WriteLine($"Lines with the word: {linesWithMatch}");
        Console.WriteLine($"Total number of substitutions: {totalUpdates}");
        Console.WriteLine($"The result is saved in a file: {outputFile}");
    }
}