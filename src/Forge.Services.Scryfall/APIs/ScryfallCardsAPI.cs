using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Forge.Services.Scryfall.Models;

namespace Forge.Services.Scryfall.APIs;

public enum UniqueMode
{
    Cards,
    Art,
    Prints
}

public enum SortMode
{
    Name,
    Set,
    Released,
    Rarity,
    Color,
    Usd,
    Tix,
    Eur,
    Cmc,
    Power,
    Toughness,
    Edhrec,
    Penny,
    Artist,
    Review
}

public enum SortOrder
{
    Auto,
    Ascending,
    Desceding
}

/// <summary>
/// API for interacting with the Scryfall Cards API.
/// </summary>
/// <remarks>See <a href="https://scryfall.com/docs/api/cards">Scryfall API Documentation</a> for more information.</remarks>
//FIXME: We may want to implement an interface at some point for testing
public class ScryfallCardsAPI
{
    private const int MaxQueryLength = 256;
    private readonly ScryfallClient _client;
    
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    internal ScryfallCardsAPI(ScryfallClient client)
    {
        _client = client;
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<ListObject<Card>> SearchAsync(
        string query, 
        UniqueMode unique = UniqueMode.Cards, 
        SortMode order = SortMode.Name, 
        SortOrder dir = SortOrder.Auto, 
        bool includeExtras = false, 
        bool includeMultilingual = false, 
        bool includeVariations = false, 
        int page = 1)
    {
        if (string.IsNullOrEmpty(query))
            throw new ArgumentException("Value cannot be null or empty.", nameof(query));
        
        if (query.Length > MaxQueryLength)
            throw new ArgumentException($"Value must be at most {MaxQueryLength} characters long.", nameof(query));
        
        if (page < 1)
            throw new ArgumentOutOfRangeException(nameof(page), "Value must be at least 1.");
        
        var encodedQuery = System.Net.WebUtility.UrlEncode(query);
        
        return _client.GetAsync<ListObject<Card>>($"cards/search?q={encodedQuery}&unique={unique.ToString().ToLower()}&order={order.ToString().ToLower()}&dir={dir.ToString().ToLower()}&include_extras={includeExtras}&include_multilingual={includeMultilingual}&include_variations={includeVariations}&page={page}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> NamedExactAsync(string name, string? set = null)
    {
        return _client.GetAsync<Card>($"cards/named?exact={name}{(set is not null ? $"&set={set}" : "")}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> NamedFuzzyAsync(string name, string? set = null)
    {
        return _client.GetAsync<Card>($"cards/named?fuzzy={name}{(set is not null ? $"&set={set}" : "")}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> AutoCompleteAsync(string query, bool includeExtras = false)
    {
        if (string.IsNullOrEmpty(query))
            throw new ArgumentException("Value cannot be null or empty.", nameof(query));
        
        if (query.Length > MaxQueryLength)
            throw new ArgumentException($"Value must be at most {MaxQueryLength} characters long.", nameof(query));
        
        var encodedQuery = System.Net.WebUtility.UrlEncode(query);
        
        return _client.GetAsync<Catalog>($"cards/autocomplete?q={encodedQuery}&include_extras={includeExtras}");
    }

    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> RandomAsync(string? query = null)
    {
        if (query is null)
            return _client.GetAsync<Card>("cards/random");
        
        if (query.Length > MaxQueryLength)
            throw new ArgumentException($"Value must be at most {MaxQueryLength} characters long.", nameof(query));
        
        var encodedQuery = System.Net.WebUtility.UrlEncode(query);
        
        return _client.GetAsync<Card>($"cards/random?q={encodedQuery}");
    }

    //FIXME: Add support for missing parameters: pretty
    public Task<ListObject<Card>> CollectionAsync(CollectionParameters parameters)
    {
        var payload = new StringContent(JsonSerializer.Serialize(parameters, _jsonSerializerOptions), Encoding.UTF8, "application/json");
        return _client.PostAsync<ListObject<Card>>("cards/collection", payload);
    }

    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> ByCollectorNumberAsync(string set, string collectorNumber, Language? language = null)
    {
        if (string.IsNullOrEmpty(set))
            throw new ArgumentException("Value cannot be null or empty.", nameof(set));
        
        if (set.Length < 3 || set.Length > 5)
            throw new ArgumentException("Value must be between 3 and 5 characters long.", nameof(set));
        
        if (string.IsNullOrEmpty(collectorNumber))
            throw new ArgumentException("Value cannot be null or empty.", nameof(collectorNumber));
        
        if (collectorNumber.Length > 10)
            throw new ArgumentException("Value must be less than 11 characters long.", nameof(collectorNumber));

        var encodedSet = System.Net.WebUtility.UrlEncode(set);
        var encodedCollectorNumber = System.Net.WebUtility.UrlEncode(collectorNumber);
        var languageQuery = language is not null ? $"/{ModelHelpers.GetJsonPropertyName(language)}" : "";
                
        return _client.GetAsync<Card>($"cards/{set}/{collectorNumber}{(language is not null ? $"/{ModelHelpers.GetJsonPropertyName(language)}" : "")}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> ByMultiverseIdAsync(long multiverseId)
    {
        return _client.GetAsync<Card>($"cards/multiverse/{multiverseId}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> ByMtgoIdAsync(long mtgoId)
    {
        return _client.GetAsync<Card>($"cards/mtgo/{mtgoId}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> ByArenaIdAsync(long arenaId)
    {
        return _client.GetAsync<Card>($"cards/arena/{arenaId}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> ByTcgPlayerIdAsync(long tcgPlayerId)
    {
        return _client.GetAsync<Card>($"cards/tcgplayer/{tcgPlayerId}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> ByCardmarketIdAsync(long cardmarketId)
    {
        return _client.GetAsync<Card>($"cards/cardmarket/{cardmarketId}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty, face, version
    public Task<Card> ById(Guid id)
    {
        return _client.GetAsync<Card>($"cards/{id}");
    }
}