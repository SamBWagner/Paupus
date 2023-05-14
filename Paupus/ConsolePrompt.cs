using System.Data;
using Paupus.Models;

namespace Paupus;

public class ConsolePrompt
{
    private static int TotalWriteWidth { get; set; } = 50;
    private static int InnerWriteWidth { get; set; } = TotalWriteWidth - 10;
    private static string Starter { get; set; } = "--- ";
    private static int StarterLength { get; set; } = Starter.Length;
    private static string Ender { get; set; } = " ---";
    private static int EnderLength { get; set; } = Ender.Length;

    public static string Prompt(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? throw new NoNullAllowedException();
    }

    public static void PrintCard(Card card, int width = 30)
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

    public static void PrintCardHeadline(string? name, string? manaCost)
    {
        manaCost ??= string.Empty;
        name ??= string.Empty;
        
        var totalInput =
            StarterLength + name.Length + manaCost.Length + EnderLength;
        if (totalInput > TotalWriteWidth)
        {
            name = $"{name.Substring(0, TotalWriteWidth - (StarterLength + EnderLength + manaCost.Length + 3))}...";
        }
        Console.WriteLine($"{Starter}{name}".PadRight(TotalWriteWidth - (manaCost.Length + EnderLength), ' ') + $"{manaCost}{Ender}");
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
    
    public static void PrintOracleText(string? oracleText)
    {
        int readHeadStartIndex = InnerWriteWidth - 1; 
        if (string.IsNullOrWhiteSpace(oracleText))
        {
            Console.WriteLine($"{Starter}No oracle text".PadRight(TotalWriteWidth - EnderLength, ' ') + $"{Ender}");
            return;
        }
        
        var sections = new List<string>();
        
        var newLineSeparatedLines = oracleText.Split('\n');
        
        // Find the end of lines
        int backwardReadHead = readHeadStartIndex;

        foreach (string newLineSeparatedLine in newLineSeparatedLines)
        {
            var line = newLineSeparatedLine;
            while (line.Length > 0)
            {
                if (line.Length < InnerWriteWidth)
                {
                    sections.Add(line.Substring(0));
                    break;
                }

                if (line.Length > InnerWriteWidth && line[readHeadStartIndex] != ' ' && line[readHeadStartIndex + 1] == ' ')
                {
                    sections.Add(line.Substring(0, backwardReadHead + 1));
                    line = line.Substring(backwardReadHead + 2);
                    continue;
                }
                
                char letter = line[backwardReadHead];
                while (letter != ' ')
                {
                    backwardReadHead--;
                    letter = line[backwardReadHead];
                }

                sections.Add(line.Substring(0,backwardReadHead));
                line = line.Substring(backwardReadHead + 1);

                backwardReadHead = readHeadStartIndex;
                if (line.Length >= InnerWriteWidth)
                {
                    letter = line[backwardReadHead];
                }
            }
            sections.Add("");
        }

        // print sections
        foreach (var section in sections)
        {
            Console.WriteLine($"{Starter}{section.PadRight(InnerWriteWidth + 2)}{Ender}");
        }
    }
}