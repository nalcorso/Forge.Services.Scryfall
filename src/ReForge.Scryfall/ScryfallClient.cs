using System.Net.Http.Headers;
using System.Text.Json;
using ComposableAsync;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RateLimiter;
using ReForge.Scryfall.APIs;
using ReForge.Scryfall.Converters;
using ReForge.Scryfall.Models;

namespace ReForge.Scryfall;

public interface IScryfallClient
{
    ScryfallCardsAPI Cards { get; }
    ScryfallSetsAPI Sets { get; }
    ScryfallRulingsAPI Rulings { get; }
    ScryfallSymbologyAPI Symbology { get; }
    ScryfallCatalogAPI Catalog { get; }
    ScryfallBulkDataAPI BulkData { get; }
    ScryfallMigrationsAPI Migrations { get; }
}

/// <summary>
/// Represents a client for interacting with the Scryfall API.
/// </summary>
public sealed class ScryfallClient : IScryfallClient
{
    private readonly TimeLimiter _rateConstraint = TimeLimiter.GetFromMaxCountByInterval(10, TimeSpan.FromSeconds(1));

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

    
    /// <summary>
    /// Provides access to the Scryfall Cards API.
    /// </summary>
    public ScryfallCardsAPI Cards => _cards.Value;
    
    /// <summary>
    /// Provides access to the Scryfall Sets API.
    /// </summary>
    public ScryfallSetsAPI Sets => _sets.Value;
    
    /// <summary>
    /// Provides access to the Scryfall Rulings API.
    /// </summary>
    public ScryfallRulingsAPI Rulings => _rulings.Value;
    
    /// <summary>
    /// Provides access to the Scryfall Symbology API.
    /// </summary>
    public ScryfallSymbologyAPI Symbology => _symbology.Value;
    
    /// <summary>
    /// Provides access to the Scryfall Catalog API.
    /// </summary>
    public ScryfallCatalogAPI Catalog => _catalog.Value;
    
    /// <summary>
    /// Provides access to the Scryfall Bulk Data API.
    /// </summary>
    public ScryfallBulkDataAPI BulkData => _bulkData.Value;
    
    /// <summary>
    /// Provides access to the Scryfall Migrations API.
    /// </summary>
    public ScryfallMigrationsAPI Migrations => _migrations.Value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScryfallClient"/> class.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> used for making HTTP requests.</param>
    /// <param name="logger">The <see cref="ILogger"/> used for logging.</param>
    /// <param name="cache">The optional <see cref="IMemoryCache"/> used for caching responses.</param>
    /// <param name="cacheOptions">The optional <see cref="MemoryCacheEntryOptions"/> for configuring cache options.</param>
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
    
    /// <summary>
    /// Creates a new instance of the ScryfallClientBuilder class.
    /// </summary>
    /// <returns>A new instance of the ScryfallClientBuilder class.</returns>
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

        await _rateConstraint;
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
        catch (JsonException)
        {
            
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
    
    internal async Task<Optional<T>> PostAsync<T>(string url, HttpContent content) where T : ResponseObjectBase
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url, nameof(url));
        ArgumentNullException.ThrowIfNull(content, nameof(content));
        
        await _rateConstraint;

        var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);
        var scryfallResponse = await response.Content.ReadAsStreamAsync();

        try
        {
            var result = await JsonSerializer.DeserializeAsync<T>(scryfallResponse, _optionsWithGlobalSettings);
            if (result is not null)
            {
                return Optional<T>.Of(result);
            }
        }
        catch (JsonException)
        {
            _logger.LogError("Error in response: {response}", await response.Content.ReadAsStringAsync());
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

