namespace ReForge.Scryfall.APIs;

public class ScryfallBulkDataAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallBulkDataAPI(ScryfallClient client)
    {
        _client = client;
    }
}