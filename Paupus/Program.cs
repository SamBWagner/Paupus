using System.Data;
using System.Diagnostics;
using Paupus;
using Paupus.Models;

var MODE = 1;

if (args.Length > 0)
{
    MODE = int.Parse(args[0]);
}

Console.WriteLine("Welcome to Paupus!");
switch (MODE)
{
    case 1:
        string input;
        try 
        {
            input = ConsolePrompt.Prompt("What card would you like to search for today?:");
        }
        catch (NoNullAllowedException e)
        {
            Console.WriteLine($"ERROR: Must input a value to Prompt() method \n {e.Message}");
            return;
        }
        
        List<ScryFallCard> cards = await CardSearch.SearchForCards(input);
        foreach (var card in cards)
        {
            Console.WriteLine($"{card.Name}");
        }
        break;
    case 2:
    {
        using StreamReader reader = new(Common.CSV_PATH);
        await using StreamWriter writer = new("C:\\Users\\Sam Wagner\\Desktop\\output.txt");
        CardParser.ConvertDragonShieldCsvToSearchableText(reader, writer);
        Process.Start("notepad.exe","C:\\Users\\Sam Wagner\\Desktop\\output.txt");
        break;
    }
}

//TODO: View Card
//TODO: Store Cards in text file for reading
//TODO: Read Cards from text file for viewing
