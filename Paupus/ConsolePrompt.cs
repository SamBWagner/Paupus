using System.Data;
using Paupus.Models;

namespace Paupus;

public class ConsolePrompt
{
    public static string Prompt(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? throw new NoNullAllowedException();
    }

    public static void PrintCard(DragonShieldCard card)
    {
        var consoleWriteWidth = 30;
        var innerContentWidth = card.CardName.Length + nameof(card.CardName).Length;
        var offset = consoleWriteWidth - innerContentWidth;
        if (offset < 0)
        {
            var truncatedCard = $"{card.CardName.Substring(0, card.CardName.Length + offset - 3)}...";
            Console.WriteLine($"--- {nameof(card.CardName)}: {truncatedCard} ---");
            return;
        }
        Console.WriteLine($"--- {nameof(card.CardName)}: {card.CardName}".PadRight(37, ' ') + "---");
    }
    
}