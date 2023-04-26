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
        var innerContentWidth = card.Name.Length;
        var offset = InnerWriteWidth - innerContentWidth;
        Console.WriteLine("".PadRight(TotalWriteWidth, '-'));

        PrintCardHeadline(card.Name, "{2}{g}{u}");
        PrintCardSeparator();
        PrintTypeLine("Creature - Goblin" , "DMR");
        PrintCardSeparator();
        PrintOracleText("{1}{R}: Goblins you control get +1/+0 and gain haste until end of turn.\nPack tactics — Whenever Battle Cry Goblin attacks, if you attacked with creatures with total power 6 or greater this combat, create a 1/1 red Goblin creature token that's tapped and attacking.");
        
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
    public static void PrintOracleText(string oracleText)
    {
        if (string.IsNullOrWhiteSpace(oracleText)) 
            throw new NoNullAllowedException("Oracle text was null or empty in PrintOracleText method");

        // TODO: Add new line character handling
        if (oracleText.Length < InnerWriteWidth)
        {
            Console.WriteLine($"{Starter}{oracleText}{Ender}");
            return;
        }

        var sections = new List<string>(); 
        
        // Find the end of lines
        int backCounter = InnerWriteWidth;
        char letter = oracleText[backCounter];
        string line;
        
        while (oracleText.Length > 0)
        {
            if (oracleText.Length < InnerWriteWidth)
            {
                sections.Add(oracleText.Substring(0));
                break;
            }

            var index = oracleText.Substring(0, backCounter).IndexOf('\n');
            if (index != -1)
            {
                sections.Add(oracleText.Substring(0, index));
                sections.Add("");
                oracleText = oracleText.Substring(index + 1);
            }
            
            while (letter != ' ')
            {
                backCounter--;
                letter = oracleText[backCounter];
            }
           
            line = oracleText.Substring(0, backCounter);
            sections.Add(oracleText.Substring(0, backCounter));
            oracleText = oracleText.Substring(backCounter + 1);
            backCounter = InnerWriteWidth;
            if (oracleText.Length >= InnerWriteWidth)
            {
                letter = oracleText[backCounter];
            }
        }

        // print sections
        foreach (var section in sections)
        {
            Console.WriteLine($"{Starter}{section.PadRight(InnerWriteWidth + 2)}{Ender}");
        }
    }
}