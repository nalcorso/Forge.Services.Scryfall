using ReForge.Scryfall.Models;

namespace ReForge.Scryfall.APIs;

/// <summary>
/// Represents a builder for creating instances of <see cref="CollectionParameters"/> as used by the Card Collection API.
/// </summary>
public sealed class CollectionParametersBuilder
{
    private readonly CollectionParameters _parameters;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionParametersBuilder"/> class.
    /// </summary>
    public CollectionParametersBuilder()
    {
        _parameters = new CollectionParameters();
    }
    
    /// <summary>
    /// Adds the specified <see cref="CollectionIdentifier"/> to the collection parameters.
    /// </summary>
    /// <param name="identifier">The <see cref="CollectionIdentifier"/> instance.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    public CollectionParametersBuilder WithIdentifier(CollectionIdentifier identifier)
    {
        _parameters.Identifiers.Add(identifier);
        return this;
    }
    
    /// <summary>
    /// Adds the specified <see cref="CollectionIdentifier"/> to the collection parameters.
    /// </summary>
    /// <param name="identifiers">The collection of <see cref="CollectionIdentifier"/> instances.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    public CollectionParametersBuilder WithIdentifiers(IEnumerable<CollectionIdentifier> identifiers)
    {
        _parameters.Identifiers.AddRange(identifiers);
        return this;
    }
    
    /// <summary>
    /// Adds a new <see cref="CollectionIdentifier"/> with the specified ID to the collection parameters.
    /// </summary>
    /// <param name="id">The ID of the card.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    public CollectionParametersBuilder WithId(Guid id)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { Id = id.ToString() });
        return this;
    }
    
    /// <summary>
    /// Adds a new <see cref="CollectionIdentifier"/> with the specified MTGO ID to the collection parameters.
    /// </summary>
    /// <param name="mtgoId">The MTGO ID of the card.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    public CollectionParametersBuilder WithMtgoId(long mtgoId)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { MtgoId = mtgoId.ToString() });
        return this;
    }
    
    /// <summary>
    /// Adds a new <see cref="CollectionIdentifier"/> with the specified MultiVerse ID to the collection parameters.
    /// </summary>
    /// <param name="multiverseId">The multiverse ID of the card.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    public CollectionParametersBuilder WithMultiverseId(long multiverseId)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { MultiverseId = multiverseId.ToString() });
        return this;
    }
    
    /// <summary>
    /// Adds a new <see cref="CollectionIdentifier"/> with the specified Oracle ID to the collection parameters.
    /// </summary>
    /// <param name="oracleId">The oracle ID of the card.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    public CollectionParametersBuilder WithOracleId(Guid oracleId)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { OracleId = oracleId.ToString() });
        return this;
    }
    
    /// <summary>
    /// Adds a new <see cref="CollectionIdentifier"/> with the specified Illustration ID to the collection parameters.
    /// </summary>
    /// <param name="illustrationId">The illustration ID of the card.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    public CollectionParametersBuilder WithIllustrationId(Guid illustrationId)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { IllustrationId = illustrationId.ToString() });
        return this;
    }
    
    /// <summary>
    /// Adds a new <see cref="CollectionIdentifier"/> with the specified name to the collection parameters.
    /// </summary>
    /// <param name="name">The name of the card.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    /// <remarks>The Scryfall API will return the first <see cref="Card"/> with the specified name.</remarks>
    public CollectionParametersBuilder WithName(string name)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { Name = name });
        return this;
    }
    
    /// <summary>
    /// Adds a new <see cref="CollectionIdentifier"/> with the specified name and set to the collection parameters.
    /// </summary>
    /// <param name="name">The name of the card.</param>
    /// <param name="set">The set code of the card.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    public CollectionParametersBuilder WithNameAndSet(string name, string set)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { Name = name, Set = set });
        return this;
    }
    
    /// <summary>
    /// Adds a new <see cref="CollectionIdentifier"/> with the specified collector number and set to the collection parameters.
    /// </summary>
    /// <param name="collectorNumber">The collector number of the card.</param>
    /// <param name="set">The set code of the card.</param>
    /// <returns>The current <see cref="CollectionParametersBuilder"/> instance.</returns>
    public CollectionParametersBuilder WithCollectorNumberAndSet(string collectorNumber, string set) 
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { CollectorNumber = collectorNumber, Set = set });
        return this;
    }
    
    /// <summary>
    /// Builds the collection parameters for use with the Card Collection API.
    /// </summary>
    /// <returns>An instance of <see cref="CollectionParameters"/> containing the specified parameters.</returns>
    public CollectionParameters Build()
    {
        return _parameters;
    }
}