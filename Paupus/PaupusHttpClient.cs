namespace Paupus;

public static class PaupusHttpClient
{
    public static HttpClient Client { get; set; }

    static PaupusHttpClient()
    {
        Client = new HttpClient()
        {
            BaseAddress = new Uri(Common.SCRY_FALL_BASE_API)
        };
    }
}