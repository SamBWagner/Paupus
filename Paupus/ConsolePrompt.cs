using System.Data;
using Paupus.Models;

namespace Paupus;

public class ConsolePrompt
{
    private static int TotalWriteWidth { get; set; } = 40;
    private static int ConsoleWriteWidth { get; set; } = 30;
    
    public static string Prompt(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? throw new NoNullAllowedException();
    }

    public static void PrintCard(DragonShieldCard card)
    {
        var innerContentWidth = card.CardName.Length;
        var offset = ConsoleWriteWidth - innerContentWidth;
        Console.WriteLine("".PadRight(TotalWriteWidth, '-'));

        if (offset < 0)
        {
            var truncatedCard = $"{card.CardName.Substring(0, card.CardName.Length + offset - 3)}...";
            Console.WriteLine($"--- {truncatedCard} ---");
            return;
        }
        Console.WriteLine($"--- {card.CardName}".PadRight(37, ' ') + "---");
        Console.WriteLine("".PadRight(TotalWriteWidth, '-'));

    }
    
}