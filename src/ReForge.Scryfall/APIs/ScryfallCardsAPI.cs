using ReForge.Scryfall.Models;

namespace ReForge.Scryfall.APIs;

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

//FIXME: We may want to implement an interface at some point for testing
public class ScryfallCardsAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallCardsAPI(ScryfallClient client)
    {
        _client = client;
    }
    
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
        return _client.GetAsync<ListObject<Card>>($"cards/search?q={query}&unique={unique.ToString().ToLower()}&order={order.ToString().ToLower()}&dir={dir.ToString().ToLower()}&include_extras={includeExtras}&include_multilingual={includeMultilingual}&include_variations={includeVariations}&page={page}");
    }
    
    public Task<Card> NamedExactAsync(string name)
    {
        return _client.GetAsync<Card>($"cards/named?exact={name}");
    }

    public Task<Card> RandomAsync()
    {
        return _client.GetAsync<Card>("cards/search?q=is%3Aslick+cmc%3Ecmc");
        //return _client.GetAsync<Card>("cards/random");
    }
}