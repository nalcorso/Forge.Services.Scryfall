using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ReForge.Scryfall;

public class ScryfallClientBuilder
{
    private HttpClient? _client = null;
    private ILogger _logger = NullLogger.Instance;
    private IMemoryCache? _cache = null;
    private MemoryCacheEntryOptions? _cacheOptions = null;
    
    public ScryfallClientBuilder WithClient(HttpClient client)
    {
        _client = client;
        return this;
    }
    
    public ScryfallClientBuilder WithLogger(ILogger logger)
    {
        _logger = logger;
        return this;
    }
    
    public ScryfallClientBuilder WithCache(IMemoryCache cache)
    {
        _cache = cache;
        return this;
    }
    
    public ScryfallClientBuilder WithDefaultCache()
    {
        _cache = new MemoryCache(new MemoryCacheOptions());
        return this;
    }
    
    public ScryfallClientBuilder WithCacheOptions(MemoryCacheEntryOptions options)
    {
        _cacheOptions = options;
        return this;
    }

    public ScryfallClient Build()
    {
        if (_client == null)
        {
            _client = new HttpClient();
        }
        
        return new ScryfallClient(_client, _logger, _cache, _cacheOptions);
    }
}