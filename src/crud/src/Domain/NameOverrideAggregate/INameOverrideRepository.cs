namespace ProjectNameOverride.Domain.NameOverrideAggregate;

public interface INameOverrideRepository : IRepository<NameOverride>
{
    Task<NameOverride?> Find(Guid id, CancellationToken cancellation = default);
    Task Add(NameOverride NameFieldOverride, CancellationToken cancellation = default);
    Task Update(NameOverride NameFieldOverride, CancellationToken cancellation = default);
    Task Delete(Guid id, CancellationToken cancellation = default);
}
