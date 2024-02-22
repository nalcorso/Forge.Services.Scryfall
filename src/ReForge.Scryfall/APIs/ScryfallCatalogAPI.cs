namespace ReForge.Scryfall.APIs;

public class ScryfallCatalogAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallCatalogAPI(ScryfallClient client)
    {
        _client = client;
    }
}