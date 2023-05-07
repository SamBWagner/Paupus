using System.Data;
using Paupus.Models;

namespace Paupus;

// TODO: Console.Width is a thing lol use it
public class ConsolePrompt
{
    private static int TotalWriteWidth { get; set; } = 40;
    private static int InnerWriteWidth { get; set; } = 30;
    private static string Starter { get; set; } = "--- ";
    private static int StarterLength { get; set; } = Starter.Length;
    private static string Ender { get; set; } = " ---";
    private static int EnderLength { get; set; } = Ender.Length;

    public static string Prompt(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? throw new NoNullAllowedException();
    }

    public static void PrintCard(Card card)
    {
        Console.WriteLine("".PadRight(TotalWriteWidth, '-'));

        PrintCardHeadline(card.Name, card.ManaCost);
        PrintCardSeparator();
        PrintTypeLine(card.TypeLine , card.SetCode);
        PrintCardSeparator();
        PrintOracleText(card?.OracleText ?? string.Empty);
        
        Console.WriteLine("".PadRight(TotalWriteWidth, '-'));
        Console.WriteLine();
    }

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

    public static void PrintCardSeparator()
    {
        Console.WriteLine(Starter + "".PadRight(InnerWriteWidth + 2, '*') + Ender);
    }
    public static void PrintTypeLine(string typeLine, string setCode)
    {
        var totalInput =
            StarterLength + typeLine.Length + setCode.Length + EnderLength;
        if (totalInput > TotalWriteWidth)
        {
            typeLine = $"{typeLine.Substring(0, TotalWriteWidth - (StarterLength + EnderLength + setCode.Length + 3))}...";
        }
        
        Console.WriteLine($"{Starter}{typeLine}".PadRight(TotalWriteWidth - (setCode.Length + EnderLength), ' ') + $"{setCode}{Ender}");
    }
    
    //TODO: Refactor and use list cumulation rather than reverse read header
    public static void PrintOracleText(string? oracleText)
    {

        // Console.WriteLine("Writting Card...");
        // Console.WriteLine($"Current oracle text is: {oracleText}");
        if (string.IsNullOrWhiteSpace(oracleText))
        {
            Console.WriteLine($"{Starter}'No oracle text".PadRight(TotalWriteWidth - EnderLength, ' ') + $"{Ender}");
            return;
        }
        
        // TODO: Add new line character handling
        if (oracleText.Length < InnerWriteWidth)
        {
            // Console.WriteLine($"Is the string shorter than the write width?: {oracleText.Length < InnerWriteWidth}");
            Console.WriteLine($"{Starter}{oracleText}{Ender}");
            return;
        }

        var sections = new List<string>(); 
        
        // Find the end of lines
        int backwardReadHead = InnerWriteWidth - 1;
        char letter = oracleText[backwardReadHead];
        
        while (oracleText.Length > 0)
        {
            if (oracleText.Length < InnerWriteWidth)
            {
                // Console.WriteLine($"Is the string shorter than the write width?: {oracleText.Length < InnerWriteWidth}");
                sections.Add(oracleText.Substring(0));
                break;
            }

            var index = oracleText.Substring(0, backwardReadHead).IndexOf('\n');
            if (index != -1)
            {
                sections.Add(oracleText.Substring(0, index));
                sections.Add("");
                oracleText = oracleText.Substring(index + 1);
            }
            
            while (letter != ' ')
            {
                // Console.WriteLine($"{oracleText} Length: {oracleText.Length}");
                // Console.WriteLine($"ReadheadValue: {backwardReadHead}");
                backwardReadHead--;
                letter = oracleText[backwardReadHead];
            }
           
            sections.Add(oracleText.Substring(0, backwardReadHead));
            oracleText = oracleText.Substring(backwardReadHead + 1);
            backwardReadHead = InnerWriteWidth - 1;
            if (oracleText.Length >= InnerWriteWidth)
            {
                letter = oracleText[backwardReadHead];
            }
        }

        // print sections
        foreach (var section in sections)
        {
            Console.WriteLine($"{Starter}{section.PadRight(InnerWriteWidth + 2)}{Ender}");
        }
    }
}