using System.Data;

namespace Paupus;

public class ConsolePrompt
{
    public static string Prompt(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? throw new NoNullAllowedException();
    }
    
}