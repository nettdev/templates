namespace NettDev.Namespace;

public interface ISomeAggregateRepository
{
    Task<SomeAggregate> Get(Guid id);
    Task<Result<bool, Error>> Add(SomeAggregate aggregate);
    Task<Result<bool, Error>> Update(SomeAggregate aggregate);
    Task<Result<bool, Error>> Delete(Guid id);
}