namespace NettDev.Namespace;

public sealed class AggregateRepository(AppDbContext dbContext) : IAggregateRepository
{
    private DbSet<Aggregate> _dbSet = dbContext.Aggregates;
    
    public async Task<Aggregate?> Find(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(Aggregate AggregateVar)
    {
        await _dbSet.AddAsync(AggregateVar);
    }
    
    public async Task Update(Aggregate AggregateVar)
    {
        await _dbSet.UpdateAsync(AggregateVar);
    }

    public async Task Delete(Guid id)
    {
        var entity = await Get(id);
        await _dbSet.DeleteAsync(entity);
    }
}
