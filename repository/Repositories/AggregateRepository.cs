namespace NettDev.Namespace;

public sealed class AggregateRepository(AppDbContext dbContext) : IAggregateRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    private DbSet<Aggregate> _dbSet = dbContext.Aggregates;
    
    public async Task<Aggregate> Get(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<Result<bool, Error>> Add(Aggregate aggregate)
    {
        await _dbSet.AddAsync(aggregate);
        return await _dbContext.SaveChangesAsync();
    }
    
    public async Task<Result<bool, Error>> Update(Aggregate aggregate)
    {
        await _dbSet.UpdateAsync(aggregate);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Result<bool, Error>> Delete(Guid id)
    {
        var entity = await Get(id);
        await _dbSet.DeleteAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }
}
