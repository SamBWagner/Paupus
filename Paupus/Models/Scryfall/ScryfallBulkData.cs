using System.Text.Json.Serialization;

namespace Paupus.Models.Scryfall;

public class ScryfallBulkData
{
    public string Object { get; set; }
    public Guid Id { get; set; }
    public string Type { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    public string Uri { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Size { get; set; }
    [JsonPropertyName("download_uri")]
    public string DownloadUri { get; set; }
    [JsonPropertyName("content_type")]
    public string ContentType { get; set; }
    [JsonPropertyName("content_encoding")]
    public string ContentEncoding { get; set; }
}

public class ScryfallBulkDataList
{
    public string Object { get; set; }
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
    public List<ScryfallBulkData> Data { get; set; }
}