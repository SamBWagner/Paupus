using System.Net.Http.Json;
using System.Web;

namespace Paupus;

public static class CardSearch
{
    //TODO: Decoupling Console and Scryfall from Search
    public static async Task<List<Models.Card>> SearchForCards()
    {
        using HttpClient client = new()
        {
            BaseAddress = new Uri(Common.SCRY_FALL_BASE_API)
        };
        List<Models.Card> outputCards = new();
        
        Console.Write("What card would you like to search for?: ");
        var encodedCardSearch = HttpUtility.UrlEncode(Console.ReadLine() ?? string.Empty);

        try
        {
            CardSearchRoot? cardSearchResults = await client.GetFromJsonAsync<CardSearchRoot>($"/cards/search?q={encodedCardSearch}");
            if (cardSearchResults != null)
            {
                foreach (var searchCard in cardSearchResults.Data)
                {
                    //TODO: Get a 'Card' from the API and map
                    Models.Card card = new Models.Card();
                    outputCards.Add();
                }
            }
            else
            {
                Console.WriteLine("No cards found!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Couldn't Connect with ScryFall! \n ERROR: {e}");
        }
        
        return outputCards;
    }

    //TODO: This is odd. Idk.
    public class CardSearchRoot
    {
        public List<Card> Data { get; set; }
    }

    public class Card
    {
        public string Name { get; set; }
    }

    private static void OutputToConsole(List<Card>? cards)
    {
        if (cards is null) return;

        foreach (Card card in cards)
        {
            Console.Write($"{card.Name}\n");
        }
    }
}