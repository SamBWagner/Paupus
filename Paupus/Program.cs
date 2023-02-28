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
        CardReader.ReadCards("C:/Users/Sam Wagner/Desktop/all-folders.csv", "C:/Users/Sam Wagner/Desktop/all-folders.txt");
        break;
}

//TODO: View Card
//TODO: Store Cards in text file for reading
//TODO: Read Cards from text file for viewing

