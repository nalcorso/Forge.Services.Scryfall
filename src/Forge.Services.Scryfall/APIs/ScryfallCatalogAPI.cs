using Forge.Services.Scryfall.Models;

namespace Forge.Services.Scryfall.APIs;

public class ScryfallCatalogAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallCatalogAPI(ScryfallClient client)
    {
        _client = client;
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> CardNamesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/card-names");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> ArtistNamesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/artist-names");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> WordBankAsync()
    {
        return _client.GetAsync<Catalog>("catalog/word-bank");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> CreatureTypesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/creature-types");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> PlaneswalkerTypesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/planeswalker-types");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> LandTypesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/land-types");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> ArtifactTypesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/artifact-types");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> EnchantmentTypesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/enchantment-types");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> SpellTypesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/spell-types");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> PowersAsync()
    {
        return _client.GetAsync<Catalog>("catalog/powers");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> ToughnessesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/toughnesses");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> LoyaltiesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/loyalties");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> WatermarksAsync()
    {
        return _client.GetAsync<Catalog>("catalog/watermarks");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> KeywordAbilitiesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/keyword-abilities");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> KeywordActionsAsync()
    {
        return _client.GetAsync<Catalog>("catalog/keyword-actions");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> AbilityWordsAsync()
    {
        return _client.GetAsync<Catalog>("catalog/ability-words");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<Catalog> SupertypesAsync()
    {
        return _client.GetAsync<Catalog>("catalog/supertypes");
    }
}