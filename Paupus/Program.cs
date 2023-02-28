using Domain;
using Infrastructure;

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
        DragonShieldCardReader.ConvertDragonShieldCsvToMtgMateText(new StreamReader(Common.CSV_PATH), "C:/Users/Sam Wagner/Desktop/all-folders.txt");
        break;
}

//TODO: View Card
//TODO: Store Cards in text file for reading
//TODO: Read Cards from text file for viewing

