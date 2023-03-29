using System.Data;
using Paupus;
using Paupus.Models;

var mode = Modes.View;

if (args.Length > 0)
{
    mode = Enum.Parse<Modes>(args[0]);
}

Console.WriteLine("Welcome to Paupus!");
switch (mode)
{
    case Modes.Search:
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

        List<ScryFallCard> scryfallCards;
        
        try
        {
            scryfallCards = await CardSearch.SearchForCards(input);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }

        if (scryfallCards.Count == 0)
        {
            Console.WriteLine("No Cards Found.");
            return;
        }

        foreach (var card in scryfallCards)
        {
            Console.WriteLine($"{card.Name}");
        }
        break;
    case Modes.Convert:
    {
        using StreamReader reader = new(Common.CSV_PATH);
        await using StreamWriter writer = new("./output.txt");
        CardParser.ConvertDragonShieldCsvToSearchableText(reader, writer);
        break; 
    }
    case Modes.View:
    {
        using StreamReader reader = new(Common.CSV_PATH);
        List<Card> cards = await CardParser.GetFromDragonShieldCsv(reader);
        var cardCount = 0;
        foreach (var card in cards)
        {
            cardCount++;
            ConsolePrompt.PrintCard(card);
        }
        Console.WriteLine($"Total: {cardCount}".PadRight(40, ' '));
        break;
    }

}

//TODO: View Card
//TODO: Store Cards in text file for reading
//TODO: Read Cards from text file for viewing
