using System.Net.Http.Json;
using System.Web;
using Domain;

namespace Paupus;

public static class CardSearch
{
    public static async Task SearchForCard()
    {
        Console.Write($"What card would you like to search for?: ");
        var encodedCardSerach = EncodeSearch(Console.ReadLine());
        using HttpClient client = new();
        var cards = await client.GetFromJsonAsync<CardSearchRoot>($"{APIs.SCRY_FALL_BASE_API}/cards/search?q={encodedCardSerach}");
        foreach (var card in cards.Data)
        {
            Console.Write($"• {card.Name}\n");
        }
    }

    private static string EncodeSearch(string cardName)
    {
        return HttpUtility.UrlEncode(cardName);
    }

    public class CardSearchRoot
    {
        public List<Card> Data { get; set; }
    }

    public class Card
    {
        public string Name { get; set; }
    }
}