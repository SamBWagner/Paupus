using System.Data;
using Paupus.Models;

namespace Paupus;

public class ConsolePrompt
{
    private static int TotalWriteWidth { get; set; } = 40;
    private static int ConsoleWriteWidth { get; set; } = 30;
    private static string Starter { get; set; } = "--- ";
    private static int StarterLength { get; set; } = Starter.Length;
    private static string Ender { get; set; } = " ---";
    private static int EnderLength { get; set; } = Ender.Length;

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
            Console.WriteLine($"{Starter}{truncatedCard}{Ender}");
            return;
        }
        Console.WriteLine($"{Starter}{card.CardName}".PadRight(TotalWriteWidth - EnderLength, ' ') + $"{Ender}");
        Console.WriteLine("".PadRight(TotalWriteWidth, '-'));
    }

    // TODO: Left align name and right align cmc
    public static void PrintCardHeadline(string name, string cmc)
    {
        // Console.WriteLine($"{Starter}{name}" + $"{cmc}{Ender}".PadLeft());
    }
    
}