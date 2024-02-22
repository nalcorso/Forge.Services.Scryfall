using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ReForge.Scryfall.APIs;
using ReForge.Scryfall.Converters;
using ReForge.Scryfall.Models;

namespace ReForge.Scryfall;

public sealed class ScryfallClient
{
    private readonly JsonSerializerOptions _optionsWithGlobalSettings = new() { Converters = { new JsonEnumMemberStringEnumConverter() } };

    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;
    private readonly IMemoryCache? _cache;
    private readonly MemoryCacheEntryOptions? _cacheOptions;

    private readonly string _userAgent = "ReForge/1.0 (Scryfall.NET)";
    
    private readonly Lazy<ScryfallCardsAPI> _cards;
    private readonly Lazy<ScryfallSetsAPI> _sets;
    private readonly Lazy<ScryfallRulingsAPI> _rulings;
    private readonly Lazy<ScryfallSymbologyAPI> _symbology;
    private readonly Lazy<ScryfallCatalogAPI> _catalog;
    private readonly Lazy<ScryfallBulkDataAPI> _bulkData;
    private readonly Lazy<ScryfallMigrationsAPI> _migrations;

    public ScryfallCardsAPI Cards => _cards.Value;
    public ScryfallSetsAPI Sets => _sets.Value;
    public ScryfallRulingsAPI Rulings => _rulings.Value;
    public ScryfallSymbologyAPI Symbology => _symbology.Value;
    public ScryfallCatalogAPI Catalog => _catalog.Value;
    public ScryfallBulkDataAPI BulkData => _bulkData.Value;
    public ScryfallMigrationsAPI Migrations => _migrations.Value;

    public ScryfallClient(HttpClient client, ILogger logger, IMemoryCache? cache, MemoryCacheEntryOptions? cacheOptions)
    {
        _httpClient = client;
        _logger = logger;
        _cache = cache;
        _cacheOptions = cacheOptions;
        
        _httpClient.BaseAddress = new Uri("https://api.scryfall.com/");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);
        
        _cards = new Lazy<ScryfallCardsAPI>(() => new ScryfallCardsAPI(this));
        _sets = new Lazy<ScryfallSetsAPI>(() => new ScryfallSetsAPI(this));
        _rulings = new Lazy<ScryfallRulingsAPI>(() => new ScryfallRulingsAPI(this));
        _symbology = new Lazy<ScryfallSymbologyAPI>(() => new ScryfallSymbologyAPI(this));
        _catalog = new Lazy<ScryfallCatalogAPI>(() => new ScryfallCatalogAPI(this));
        _bulkData = new Lazy<ScryfallBulkDataAPI>(() => new ScryfallBulkDataAPI(this));
        _migrations = new Lazy<ScryfallMigrationsAPI>(() => new ScryfallMigrationsAPI(this));
    }
    
    public static ScryfallClientBuilder Create()
    {
        return new ScryfallClientBuilder();
    }
    
    internal async Task<Optional<T>> GetAsync<T>(string url) where T : ResponseObjectBase
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url, nameof(url));
        
        //FIXME: Replace with a NullCache
        if (_cache is not null)
        {
            if (_cache.TryGetValue(url, out T? cached))
            {
                _logger.LogDebug("Cache hit for {url}", url);
                return Optional<T>.Of(cached!);
            }
        }
        
        _logger.LogDebug("Cache miss for {url}", url);
        
        var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
        var scryfallResponse = await response.Content.ReadAsStreamAsync();

        try
        {
            var result = await JsonSerializer.DeserializeAsync<T>(scryfallResponse, _optionsWithGlobalSettings);
            if (result is not null)
            {
                _cache?.Set(url, result, _cacheOptions);
                return Optional<T>.Of(result);
            }
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Error deserializing {url} >> {response}", url, await response.Content.ReadAsStringAsync());
        }
        
        scryfallResponse.Seek(0, SeekOrigin.Begin);
        var error = await JsonSerializer.DeserializeAsync<Error>(scryfallResponse, _optionsWithGlobalSettings);
        if (error is null) throw new InvalidOperationException("Failed to deserialize error response");
        
        foreach (var warning in error.Warnings ?? Enumerable.Empty<string>())
        {
            _logger.LogWarning(warning);
        }
        
        return Optional<T>.OfException(new InvalidOperationException(error.Details));
    }
}

