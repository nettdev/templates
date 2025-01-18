namespace NettDev.Namespace;

public sealed class AppDbContext(IConfiguration configuration) : DbContext, IAppDbContext, IUnitOfWork
{
    private readonly IConfiguration _configuration = configuration;

    #if (aggregateName != "")
    public {Aggregate} {Aggregate}s => Set<{Aggregate}>();
    #endif

    public async Task<bool> Commit(CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken) > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["PostgresConnectionString"]!);
        base.OnConfiguring(optionsBuilder);
    }
}
