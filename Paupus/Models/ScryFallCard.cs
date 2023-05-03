namespace Paupus.Models;

public class ScryFallCard
{
	public string Object { get; set; }
	public Guid Id { get; set; }
	public string OracleId { get; set; }
	public List<int> MultiverseIds { get; set; }
	public int MtgOnlineId { get; set; }
	public int MtgArenaId { get; set; }
	public int TcgPlayerId { get; set; }
	public string Name { get; set; }
	public string LanguageCode { get; set; }
	public DateTime ReleaseDate { get; set; }
	public string ApiUri { get; set; }
	public string SiteUri { get; set; }
	public string Layout { get; set; }
	public bool HasHighResImage { get; set; }
	public string ImageStatus { get; set; }
	public Dictionary<string, string> ImageUris { get; set; }
	public string ManaCost { get; set; }
	public string ConvertedManaCost { get; set; }
	public string TypeLine { get; set; }
	public string OracleText { get; set; }
	public string Power { get; set; }
	public string Toughness { get; set; }
	public List<string> Colors { get; set; }
	public List<string> ColorIdentity { get; set; }
	public List<string> Keywords { get; set; }
	public List<AllParts> AllParts { get; set; }
	public Dictionary<string, string> Legalities { get; set; }
	public List<string> Games { get; set; }
	public bool IsReserved { get; set; }
	public bool IsNonFoil { get; set; }
	public List<string> Finishes { get; set; }
	public bool IsOversized { get; set; }
	public bool isPromo { get; set; }
	public bool IsVariation { get; set; }
	public Guid SetId { get; set; }
	public string SetCode { get; set; }
	public string SetName { get; set; }
	public string SetUri { get; set; }
	public string RulingsUri { get; set; }
	public string PrintsSearchUri { get; set; }
	public string CollectorNumber { get; set; }
	public bool IsDigital { get; set; }
	public string Rarity { get; set; }
	public Guid CardBackId { get; set; }
	public string Artist { get; set; }
	public List<string> ArtistIds { get; set; }
	public Guid IllistrationId { get; set; }
	public string Bordercolor { get; set; }
	public string Frame { get; set; }
	public bool IsFullArt { get; set; }
	public bool IsTextLess { get; set; }
	public bool IsBooster { get; set; }
	public bool IsStorySpotlight { get; set; }
	public int EdhRecRank { get; set; }
	public int PennyRank { get; set; }
	public Dictionary<string, double?> Prices { get; set; }
	public Dictionary<string, string> RelatedUris { get; set; }
	public Dictionary<string, string> PurchaseUris { get; set; }
}

public class AllParts
{
	public string Object { get; set; }
	public Guid Id { get; set; }
	public string Component { get; set; }
	public string Name { get; set; }
	public string TypeLine { get; set; }
	public string Uri { get; set; }
}

public class ScryFallSearchList
{
	public string Object { get; set; }
	public int Totalcards { get; set; }
	public bool HasMore { get; set; }
	public string NextPage { get; set; }
	public List<ScryFallCard> Data { get; set; }
}