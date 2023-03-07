using System.Diagnostics;
using Paupus;

var MODE = 2;

if (args.Length > 0)
{
    MODE = int.Parse(args[0]);
}

Console.WriteLine("Welcome to Paupus!");
switch (MODE)
{
    case 1:
        await CardSearch.SearchForCard();
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

