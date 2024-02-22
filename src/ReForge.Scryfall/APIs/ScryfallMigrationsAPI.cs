namespace ReForge.Scryfall.APIs;

public class ScryfallMigrationsAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallMigrationsAPI(ScryfallClient client)
    {
        _client = client;
    }
}