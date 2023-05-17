using System.Data;
using System.Net.Http.Json;
using System.Web;
using Paupus.Models;
using Paupus.Models.Scryfall;

namespace Paupus;

public static class CardSearch
{
    public static async Task<List<Card>> SearchForCards(string input)
    {
        var encodedCardSearch = HttpUtility.UrlEncode(input);
        var cardSearchResults =
            await PaupusHttpClient.Client.GetFromJsonAsync<ScryFallSearchList>($"/cards/search?q={encodedCardSearch}")
            ?? throw new NoNullAllowedException();

        return cardSearchResults.Data
            .Select(Card
                .ToCardFromScryfallCard)
            .ToList();
    }
}