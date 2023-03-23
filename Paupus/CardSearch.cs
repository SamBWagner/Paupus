using System.Data;
using System.Net.Http.Json;
using System.Web;
using Paupus.Models;

namespace Paupus;

public static class CardSearch
{
    public static async Task<List<ScryFallCard>> SearchForCards(string input)
    {
        var encodedCardSearch = HttpUtility.UrlEncode(input);
        List<ScryFallCard>? cardSearchResults = null!;
        //TODO: Catch at highest level possible for useful stack traces. Not on the method. Dickhead.
        try
        {
            //TODO: Work out how to map this properly
            //NOTE: Unable to parse snake case 
            cardSearchResults =
                await PaupusHttpClient.Client.GetFromJsonAsync<List<ScryFallCard>>($"/cards/search?q={encodedCardSearch}") ??
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