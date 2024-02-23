namespace ReForge.Scryfall.APIs;

public class CollectionParametersBuilder
{
    private readonly CollectionParameters _parameters;
    
    public CollectionParametersBuilder()
    {
        _parameters = new CollectionParameters();
    }
    
    public CollectionParametersBuilder WithIdentifier(CollectionIdentifier identifier)
    {
        _parameters.Identifiers.Add(identifier);
        return this;
    }
    
    public CollectionParametersBuilder WithIdentifiers(IEnumerable<CollectionIdentifier> identifiers)
    {
        _parameters.Identifiers.AddRange(identifiers);
        return this;
    }
    
    public CollectionParametersBuilder WithId(Guid id)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { Id = id.ToString() });
        return this;
    }
    
    public CollectionParametersBuilder WithMtgoId(long mtgoId)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { MtgoId = mtgoId.ToString() });
        return this;
    }
    
    public CollectionParametersBuilder WithMultiverseId(long multiverseId)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { MultiverseId = multiverseId.ToString() });
        return this;
    }
    
    public CollectionParametersBuilder WithOracleId(Guid oracleId)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { OracleId = oracleId.ToString() });
        return this;
    }
    
    public CollectionParametersBuilder WithIllustrationId(Guid illustrationId)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { IllustrationId = illustrationId.ToString() });
        return this;
    }
    
    public CollectionParametersBuilder WithName(string name)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { Name = name });
        return this;
    }
    
    public CollectionParametersBuilder WithNameAndSet(string name, string set)
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { Name = name, Set = set });
        return this;
    }
    
    public CollectionParametersBuilder WithCollectorNumberAndSet(string collectorNumber, string set) 
    {
        _parameters.Identifiers.Add(new CollectionIdentifier { CollectorNumber = collectorNumber, Set = set });
        return this;
    }
    
    public CollectionParameters Build()
    {
        return _parameters;
    }
}