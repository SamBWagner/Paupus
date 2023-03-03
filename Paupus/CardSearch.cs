using System.Net.Http.Json;
using System.Web;

namespace Paupus;

public static class CardSearch
{
    public static async Task SearchForCard()
    {
        Console.Write("What card would you like to search for?: ");
        var encodedCardSearch = EncodeSearch(Console.ReadLine() ?? string.Empty);
        using HttpClient client = new();
        try
        {
            var cards = await client.GetFromJsonAsync<CardSearchRoot>($"{Common.SCRY_FALL_BASE_API}/cards/search?q={encodedCardSearch}");
            foreach (var card in cards.Data)
            {
                Console.Write($"• {card.Name}\n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Couldn't Connect with ScryFall! \n ERROR: {e}");
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