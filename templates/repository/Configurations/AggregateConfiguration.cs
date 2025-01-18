namespace NettDev.Namespace;

internal sealed class AggregateConfiguration : IEntityTypeConfiguration<Aggregate>
{
    public void Configure(EntityTypeBuilder<Aggregate> builder)
    {
        builder
            .ToTable("Aggregates");

        builder
            .HasKey(p => p.Id);
    }
}
