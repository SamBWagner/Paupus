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
        CardParser.ParseLine("New,1,0,\"Aron, Benalia's Ruin\",DMU,Dominaria United,292,NearMint,Normal,English,0.06,2022-09-19,0.01,0.17,0.03");
        break;
}

//TODO: View Card
//TODO: Store Cards in text file for reading
//TODO: Read Cards from text file for viewing

