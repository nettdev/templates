namespace ProjectNameOverride.Infrastructure.Persistence.Configurations;

internal sealed class NameOverrideConfiguration : IEntityTypeConfiguration<NameOverride>
{
    public void Configure(EntityTypeBuilder<NameOverride> builder)
    {
        builder
            .ToTable("NameOverrides");

        builder
            .HasKey(p => p.Id);
    }
}
