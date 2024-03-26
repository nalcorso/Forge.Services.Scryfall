using Forge.Services.Scryfall.Models;

namespace Forge.Services.Scryfall.APIs;

/// <summary>
/// API for interacting with the Scryfall Bulk Data API.
/// </summary>
/// <remarks>See <a href="https://scryfall.com/docs/api/bulk-data">Scryfall API Documentation</a> for more information.</remarks>
public class ScryfallBulkDataAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallBulkDataAPI(ScryfallClient client)
    {
        _client = client;
    }
    
    //FIXME: Add support for missing parameters: pretty
    public Task<ListObject<BulkData>> AllAsync()
    {
        return _client.GetAsync<ListObject<BulkData>>("bulk-data");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<BulkData> ByIdAsync(Guid id)
    {
        return _client.GetAsync<BulkData>($"bulk-data/{id}");
    }
    
    //FIXME: Add support for missing parameters: format, pretty
    public Task<BulkData> ByTypeAsync(BulkDataType type)
    {
        return _client.GetAsync<BulkData>($"bulk-data/{ModelHelpers.GetJsonPropertyName(type)}");
    }

}