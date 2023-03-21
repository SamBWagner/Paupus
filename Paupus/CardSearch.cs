using System.Data;
using System.Net.Http.Json;
using System.Web;
using Paupus.Models;

namespace Paupus;

public static class CardSearch
{
    public static async Task<List<ScryFallCard>> SearchForCards(string input)
    {
        using HttpClient client = new()
        {
            BaseAddress = new Uri(Common.SCRY_FALL_BASE_API)
        };
        var encodedCardSearch = HttpUtility.UrlEncode(input);
        List<ScryFallCard>? cardSearchResults = null!;
        try
        {
            //TODO: Work out how to map this properly
            cardSearchResults =
                await client.GetFromJsonAsync<List<ScryFallCard>>($"/cards/search?q={encodedCardSearch}") ??
                throw new NoNullAllowedException();
        }
        catch (NoNullAllowedException e)
        {
            Console.WriteLine($"No cards found!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Couldn't Connect with ScryFall! \n ERROR: {e}");
        }
        
        return cardSearchResults;

    }
    
}