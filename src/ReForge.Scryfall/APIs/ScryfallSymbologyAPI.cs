namespace ReForge.Scryfall.APIs;

public class ScryfallSymbologyAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallSymbologyAPI(ScryfallClient client)
    {
        _client = client;
    }
}