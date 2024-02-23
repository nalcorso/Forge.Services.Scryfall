using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ReForge.Scryfall;

/// <summary>
/// Builder class for creating instances of <see cref="ScryfallClient"/>.
/// </summary>
public class ScryfallClientBuilder
{
    private HttpClient? _client = null;
    private ILogger _logger = NullLogger.Instance;
    private IMemoryCache? _cache = null;
    private MemoryCacheEntryOptions? _cacheOptions = null;
    
    /// <summary>
    /// Sets the <see cref="HttpClient"/> to be used by the <see cref="ScryfallClient"/>.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance.</param>
    /// <returns>The current <see cref="ScryfallClientBuilder"/> instance.</returns>
    public ScryfallClientBuilder WithClient(HttpClient client)
    {
        _client = client;
        return this;
    }
    
    /// <summary>
    /// Sets the <see cref="ILogger"/> to be used by the <see cref="ScryfallClient"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    /// <returns>The current <see cref="ScryfallClientBuilder"/> instance.</returns>
    public ScryfallClientBuilder WithLogger(ILogger logger)
    {
        _logger = logger;
        return this;
    }
    
    /// <summary>
    /// Sets the <see cref="IMemoryCache"/> to be used by the <see cref="ScryfallClient"/>.
    /// </summary>
    /// <param name="cache">The <see cref="IMemoryCache"/> instance.</param>
    /// <returns>The current <see cref="ScryfallClientBuilder"/> instance.</returns>
    public ScryfallClientBuilder WithCache(IMemoryCache cache)
    {
        _cache = cache;
        return this;
    }
    
    /// <summary>
    /// Sets the default <see cref="IMemoryCache"/> with an expiration time of 1 hour.
    /// </summary>
    /// <returns>The current <see cref="ScryfallClientBuilder"/> instance.</returns>
    public ScryfallClientBuilder WithDefaultCache()
    {
        _cacheOptions = new MemoryCacheEntryOptions 
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
        };
        
        _cache = new MemoryCache(new MemoryCacheOptions());
        return this;
    }
    
    /// <summary>
    /// Sets the <see cref="MemoryCacheEntryOptions"/> to be used by the <see cref="ScryfallClient"/>.
    /// </summary>
    /// <param name="options">The <see cref="MemoryCacheEntryOptions"/> instance.</param>
    /// <returns>The current <see cref="ScryfallClientBuilder"/> instance.</returns>
    public ScryfallClientBuilder WithCacheOptions(MemoryCacheEntryOptions options)
    {
        _cacheOptions = options;
        return this;
    }

    /// <summary>
    /// Builds and returns an instance of <see cref="ScryfallClient"/>.
    /// </summary>
    /// <returns>An instance of <see cref="ScryfallClient"/>.</returns>
    public ScryfallClient Build()
    {
        if (_client == null)
        {
            _client = new HttpClient();
        }
        
        return new ScryfallClient(_client, _logger, _cache, _cacheOptions);
    }
}