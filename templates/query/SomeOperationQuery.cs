namespace NettDev.Namespace;

public sealed class SomeOperationQuery(IAppDbContext dbContext)
{
    private readyonly DbSet<AggregateName> _dbSet = dbContext.AggregateNames;

    public async Task<IEnumerable<SomeOperationResponse>> Execute(SomeOperationRequest request)
    {
        return [];
    }
}
