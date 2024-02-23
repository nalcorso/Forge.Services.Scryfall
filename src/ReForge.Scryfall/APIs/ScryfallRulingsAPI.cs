using ReForge.Scryfall.Models;

namespace ReForge.Scryfall.APIs;

public class ScryfallRulingsAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallRulingsAPI(ScryfallClient client)
    {
        _client = client;
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<ListObject<Ruling>>> ByMultiverseIdAsync(int id)
    {
        return _client.GetAsync<ListObject<Ruling>>($"cards/multiverse/{id}/rulings");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<ListObject<Ruling>>> ByMtgoIdAsync(int id)
    {
        return _client.GetAsync<ListObject<Ruling>>($"cards/mtgo/{id}/rulings");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<ListObject<Ruling>>> ByArenaIdAsync(int id)
    {
        return _client.GetAsync<ListObject<Ruling>>($"cards/arena/{id}/rulings");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<ListObject<Ruling>>> ByCollectorNumberAsync(string set, string collectorNumber)
    {
        if (string.IsNullOrEmpty(set))
            throw new ArgumentException("Value cannot be null or empty.", nameof(set));
        
        if (set.Length < 3 || set.Length > 5)
            throw new ArgumentException("Value must be between 3 and 5 characters long.", nameof(set));
        
        if (string.IsNullOrEmpty(collectorNumber))
            throw new ArgumentException("Value cannot be null or empty.", nameof(collectorNumber));
        
        if (collectorNumber.Length > 10)
            throw new ArgumentException("Value must be less than 11 characters long.", nameof(collectorNumber));
        
        return _client.GetAsync<ListObject<Ruling>>($"cards/{set}/{collectorNumber}/rulings");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Optional<ListObject<Ruling>>> ByIdAsync(Guid id)
    {
        return _client.GetAsync<ListObject<Ruling>>($"cards/{id}/rulings");
    }
}