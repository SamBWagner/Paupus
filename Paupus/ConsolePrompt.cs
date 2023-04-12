using System.Data;
using Paupus.Models;

namespace Paupus;

// TODO: Console.Width is a thing lol use it
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

    // TODO: Refactor to have the PrintCard method simply print a square that takes a formatted string
    public static void PrintCard(Card card)
    {
        var innerContentWidth = card.Name.Length;
        var offset = ConsoleWriteWidth - innerContentWidth;
        Console.WriteLine("".PadRight(TotalWriteWidth, '-'));

        PrintCardHeadline(card.Name, "{2}{g}{u}");
        Console.WriteLine("".PadRight(TotalWriteWidth, '-'));
    }

    // TODO: This should simply take the card, and then format a string to be rendered by the UI framework above
    public static void PrintCardHeadline(string name, string cmc)
    {
        var totalInput =
            StarterLength + name.Length + cmc.Length + EnderLength;
        if (totalInput > TotalWriteWidth)
        {
            name = $"{name.Substring(0, TotalWriteWidth - (StarterLength + EnderLength + cmc.Length + 3))}...";
        }
        Console.WriteLine($"{Starter}{name}".PadRight(TotalWriteWidth - (cmc.Length + EnderLength), ' ') + $"{cmc}{Ender}");
    }
    
}