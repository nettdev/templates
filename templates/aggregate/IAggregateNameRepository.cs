namespace NettDev.Namespace;

public interface IAggregateNameRepository
{
    Task<AggregateName?> Find(Guid id);
    Task Add(AggregateName AggregateVar);
    Task Update(AggregateName AggregateVar);
    Task Delete(Guid id);
}