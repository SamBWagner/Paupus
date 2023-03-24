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
        List<ScryFallCard>? cardSearchResults =
            await PaupusHttpClient.Client.GetFromJsonAsync<List<ScryFallCard>>($"/cards/search?q={encodedCardSearch}") ?? 
            throw new NoNullAllowedException();
        return cardSearchResults;
        }
    
}