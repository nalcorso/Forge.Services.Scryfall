using ReForge.Scryfall.Models;

namespace ReForge.Scryfall.APIs;

public class ScryfallSetsAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallSetsAPI(ScryfallClient client)
    {
        _client = client;
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<ListObject<Set>>> AllAsync()
    {
        return _client.GetAsync<ListObject<Set>>("sets");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<Set>> ByCodeAsync(string code)
    {
        if (string.IsNullOrEmpty(code))
            throw new ArgumentException("Value cannot be null or empty.", nameof(code));

        if (code.Length < 3 || code.Length > 5)
            throw new ArgumentException("Value must be between 3 and 5 characters long.", nameof(code));
        
        return _client.GetAsync<Set>($"sets/{code}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<Set>> ByTcgPlayerIdAsync(int id)
    {
        return _client.GetAsync<Set>($"sets/tcgplayer/{id}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<Set>> ByIdAsync(Guid id)
    {
        return _client.GetAsync<Set>($"sets/{id}");
    }
    
}