class Program
{
    static void Main()
    {
        Console.WriteLine("Enter file path:");
        string inputPath = Console.ReadLine();

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("I can`t find file!");
            return;
        }

        string content = File.ReadAllText(inputPath);
        char[] rever = content.ToCharArray();
        Array.Reverse(rever);

        string reversedPath = "reversed.txt";
        File.WriteAllText(reversedPath, new string(rever));

    }
}