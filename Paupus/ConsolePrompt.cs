using System.Data;

namespace Paupus;

public class ConsolePrompt
{
    public static string Prompt(string prompt)
    {
        Console.Write(prompt);
        try
        {
            return Console.ReadLine() ?? throw new NoNullAllowedException();
        }
        catch (NoNullAllowedException e)
        {
            Console.WriteLine($"ERROR: No Null allowed \n {e.Message}");
            throw;
        }
    }
    
}