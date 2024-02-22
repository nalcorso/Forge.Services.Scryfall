namespace ReForge.Scryfall.APIs;

public class ScryfallRulingsAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallRulingsAPI(ScryfallClient client)
    {
        _client = client;
    }
}