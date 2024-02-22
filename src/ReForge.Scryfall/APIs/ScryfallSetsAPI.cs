using ReForge.Scryfall.Models;

namespace ReForge.Scryfall.APIs;

public class ScryfallSetsAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallSetsAPI(ScryfallClient client)
    {
        _client = client;
    }
    
    public Task<Optional<ListObject<Set>>> AllAsync()
    {
        return _client.GetAsync<ListObject<Set>>("sets");
    }
    
    public Task<Optional<Set>> ByCodeAsync(string code)
    {
        return _client.GetAsync<Set>($"sets/{code}");
    }
    
    public Task<Optional<Set>> ByTcgPlayerIdAsync(int id)
    {
        return _client.GetAsync<Set>($"sets/tcgplayer/{id}");
    }
    
    public Task<Optional<Set>> ByIdAsync(Guid id)
    {
        return _client.GetAsync<Set>($"sets/{id}");
    }
    
}