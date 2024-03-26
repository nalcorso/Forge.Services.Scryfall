using Forge.Services.Scryfall.Models;

namespace Forge.Services.Scryfall.APIs;

public class ScryfallMigrationsAPI
{
    private readonly ScryfallClient _client;

    internal ScryfallMigrationsAPI(ScryfallClient client)
    {
        _client = client;
    }
    
    public Task<ListObject<CardMigration>> AllAsync(int page = 1)
    {
        return _client.GetAsync<ListObject<CardMigration>>("migrations?page=" + page);
    }
    
    public Task<CardMigration> ByIdAsync(Guid id)
    {
        return _client.GetAsync<CardMigration>($"migrations/{id}");
    }
}