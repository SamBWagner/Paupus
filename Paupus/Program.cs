using System.Data;
using System.Net.Http.Json;
using Paupus;
using Paupus.Models;
using Paupus.Models.Scryfall;

var mode = Mode.UpdateData;

List<Card> cards;

if (args.Length > 0)
{
    mode = Enum.Parse<Mode>(args[0]);
}

mode = Enum.Parse<Mode>(ConsolePrompt.Prompt("Welcome to Paupus! Please enter a mode you'd like to use: "));

switch (mode)
{
    case Mode.Search:
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
        
        try
        {
            cards = await CardSearch.SearchForCards(input);
        }
        catch (Exception e)
        {
            Console.WriteLine($"SearchForCards() failed: {e}");
            return;
        }

        if (cards.Count == 0)
        {
            Console.WriteLine("No Cards Found.");
            return;
        }

        foreach (var card in cards)
        {
            ConsolePrompt.PrintCard(card);
        }
        break;
    case Mode.Convert:
    {
        using StreamReader reader = new(Common.CSV_PATH);
        await using StreamWriter writer = new("./output.txt");
        CardParser.ConvertDragonShieldCsvToSearchableText(reader, writer);
        break; 
    }
    case Mode.View:
    {
        using StreamReader reader = new(Common.CSV_PATH);
        cards = await CardParser.GetFromDragonShieldCsv(reader);
        var cardCount = 0;
        foreach (var card in cards)
        {
            cardCount++;
            ConsolePrompt.PrintCard(card);
        }
        Console.WriteLine($"Total: {cardCount}".PadRight(40, ' '));
        break;
    }
    case Mode.UpdateData:
        //TODO: Download the card data from scryfall to a local instance
        var bulkData = await PaupusHttpClient.Client.GetFromJsonAsync<ScryfallBulkDataList>("bulk-data");
        Console.WriteLine($"Found this many data points: {bulkData?.Data.Count}");
        break;
}
