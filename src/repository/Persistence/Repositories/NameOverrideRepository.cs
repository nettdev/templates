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
    
    public async Task<NameOverride?> Find(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(NameOverride NameFieldOverride)
    {
        await _dbSet.AddAsync(NameFieldOverride);
    }
    
    public async Task Update(NameOverride NameFieldOverride)
    {
        _dbSet.Update(NameFieldOverride);
        await Task.CompletedTask;
    }

    public async Task Delete(Guid id)
    {
        if (await Find(id) is {} NameFieldOverride)
        {
            _dbSet.Delete(NameFieldOverride);
        }
    }
}
