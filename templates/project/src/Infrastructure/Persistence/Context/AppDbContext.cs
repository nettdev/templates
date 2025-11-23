namespace Nett.BackOffice.Infrastructure.Persistence.Context;

[ExcludeFromCodeCoverage]
public class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public async Task<bool> Commit(CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken) > 0;
    }
}
