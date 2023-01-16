using Domain;

namespace Paupus;

public static class CardSearch
{
    public static void SearchForCard()
    {
        Console.Write($"What card would you like to search for?: ");
        string? nameOfCard = Console.ReadLine();

        HttpClient client = new();
        var card = client.GetAsync($"{APIs.ScryFallBaseApi}");
        Console.Write($"You searched for {nameOfCard}. ");
        Console.WriteLine("(Press enter to go back to the menu)");
        Console.Read();
    }
}