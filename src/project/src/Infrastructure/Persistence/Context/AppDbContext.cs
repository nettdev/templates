namespace NameOverride.Infrastructure.Persistence.Context;

[ExcludeFromCodeCoverage]
public class AppDbContext : DbContext, IUnitOfWork
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _configuration = configuration;
    }

    public async Task<bool> Commit(CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken) > 0;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {        
        optionsBuilder.UseNpgsql(_configuration["POSTGRES"], options =>
        {
            options.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorCodesToAdd: null);
            options.CommandTimeout(30);
            options.ConfigureDataSource(builder =>
            {
                builder.Name = "NameOverride";
            });
        });
        base.OnConfiguring(optionsBuilder);
    }
}
