namespace NettDev.Namespace;

public sealed class AppDbContext : DbContext, IAppDbContext
{
    private readonly IConfiguration _configuration = configuration;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["PostgresConnectionString"]!);
        base.OnConfiguring(optionsBuilder);
    }
}
