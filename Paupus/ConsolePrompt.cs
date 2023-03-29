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

        PrintCardHeadline(card.CardName, "{2}{g}{u}");
        Console.WriteLine("".PadRight(TotalWriteWidth, '-'));
    }

    public static void PrintCardHeadline(string name, string cmc)
    {
        var totalInput =
            StarterLength + name.Length + cmc.Length + EnderLength;
        if (totalInput > TotalWriteWidth)
        {
            name = $"{name.Substring(0, TotalWriteWidth - (StarterLength + EnderLength + cmc.Length + 3))}...";
        }
        //TODO: Fix normal output. Mafs == hard
        Console.WriteLine($"{Starter}{name}".PadRight(TotalWriteWidth - (StarterLength + name.Length), ' ') + $"{cmc}{Ender}");
    }
    
}