using System.Net.Quic;
using ReForge.Scryfall.Models;

namespace ReForge.Scryfall.APIs;

public class ScryfallSymbologyAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallSymbologyAPI(ScryfallClient client)
    {
        _client = client;
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<ListObject<CardSymbol>>> AllAsync()
    {
        return _client.GetAsync<ListObject<CardSymbol>>("symbology");
    }
    
    public Task<Optional<ManaCost>> ParseManaCostAsync(string manaCost)
    {
        if (string.IsNullOrEmpty(manaCost))
            throw new ArgumentException("Value cannot be null or empty.", nameof(manaCost));
        
        return _client.GetAsync<ManaCost>($"symbology/parse-mana?cost={manaCost}");
    }
}