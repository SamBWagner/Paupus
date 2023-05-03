using System.Data;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using Paupus.Models;

namespace Paupus;

public static class CardSearch
{
    public static async Task<List<Card>> SearchForCards(string input)
    {
        var encodedCardSearch = HttpUtility.UrlEncode(input);
        var cardSearchResults =
            await PaupusHttpClient.Client.GetFromJsonAsync<ScryFallSearchList>($"/cards/search?q={encodedCardSearch}") ?? 
            throw new NoNullAllowedException();

        var mySerializer = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        // TODO: Configure the serialization of the JSON to the new cool object :)
        Console.WriteLine(JsonSerializer.Serialize(cardSearchResults.Data.First(), mySerializer));
        return null;
        }
    
}