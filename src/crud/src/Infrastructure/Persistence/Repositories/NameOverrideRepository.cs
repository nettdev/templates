namespace ProjectNameOverride.Infrastructure.Persistence.Repositories;

public sealed class NameOverrideRepository(AppDbContext dbContext) : Repository<NameOverride>, INameOverrideRepository
{
    private readonly DbSet<NameOverride> _dbSet = dbContext.NameOverrides;

    protected override IQueryable<NameOverride> Queryable => _dbSet;
    protected override Dictionary<string, Expression<Func<NameOverride, object>>> SortMap => new()
    {
        [nameof(NameOverride.Id)] = p => p.Id,
        [nameof(NameOverride.Name)] = p => p.Name,
    };
    
    public async Task<NameOverride?> Find(Guid id, CancellationToken cancellation = default)
    {
        return await _dbSet.FindAsync(id, cancellation);
    }

    public async Task Add(NameOverride NameFieldOverride, CancellationToken cancellation = default)
    {
        await _dbSet.AddAsync(NameFieldOverride, cancellation);
    }
    
    public async Task Update(NameOverride NameFieldOverride, CancellationToken cancellation = default)
    {
        _dbSet.Update(NameFieldOverride);
        await Task.CompletedTask;
    }

    public async Task Delete(Guid id, CancellationToken cancellation = default)
    {
        if (await Find(id, cancellation) is {} NameFieldOverride)
        {
            _dbSet.Remove(NameFieldOverride);
        }
    }
}
