using Paupus;

const string EXIT_VALUE = "2";
string? choice;

Console.WriteLine("Welcome to Paupus!");
do
{
    Console.Clear();
    Console.WriteLine("1. Search for a card online");
    Console.WriteLine($"{EXIT_VALUE}. Exit");
    Console.Write("How can I help you today?: ");
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            CardSearch.SearchForCard();
            break;
    }
} while (choice != EXIT_VALUE);
