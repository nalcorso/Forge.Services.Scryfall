using ReForge.Scryfall.Models;

namespace ReForge.Scryfall.APIs;

public class ScryfallSetsAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallSetsAPI(ScryfallClient client)
    {
        _client = client;
    }
    
    public Task<ListObject<Set>> AllAsync()
    {
        return _client.GetAsync<ListObject<Set>>("sets");
    }
    
    public Task<Set> ByCodeAsync(string code)
    {
        return _client.GetAsync<Set>($"sets/{code}");
    }
    
    public Task<Set> ByTcgPlayerIdAsync(int id)
    {
        return _client.GetAsync<Set>($"sets/tcgplayer/{id}");
    }
    
    public Task<Set> ByIdAsync(Guid id)
    {
        return _client.GetAsync<Set>($"sets/{id}");
    }
    
}