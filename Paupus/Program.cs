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
        List<Card> cards = await CardSearch.SearchForCards();
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

