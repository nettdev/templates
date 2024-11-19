namespace NettDev.Namespace;

public sealed class SomeOperationQuery(IAppDbContext dbContext)
{
    private readyonly IAppDbContext _dbContext = dbContext;

    public async Task<IEnumerable<SomeOperationResponse>> Execute(SomeOperationRequest request)
    {
        return [];
    }
}
