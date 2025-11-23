namespace ProjectNameOverride.Domain.NameOverrideAggregate;

public interface INameOverrideRepository : IRepository<NameOverride>
{
    Task<NameOverride?> Find(Guid id);
    Task Add(NameOverride NameFieldOverride);
    Task Update(NameOverride NameFieldOverride);
    Task Delete(Guid id);
}
