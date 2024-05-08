using System;
using System.IO;

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string userInput = args.Length > 0 ? args[0] : "default.log";
        
        userInput = SanitizeInput(userInput);
        LogUserInput(userInput);
        
        string filePath = Path.Combine("files", userInput);
        if (File.Exists(filePath))
        {
            string fileContent = ReadFileContent(filePath);
            Console.WriteLine("File content: " + fileContent);
        }
    }

    private static string SanitizeInput(string input)
    {
        return input.Replace("\n", "").Replace("\r", "");
    }

    private static void LogUserInput(string userInput)
    {
        using (StreamWriter sw = File.AppendText("logfile.log"))
        {
            sw.WriteLine("User input: " + userInput);
        }
    }

    private static string ReadFileContent(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}
