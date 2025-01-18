namespace NettDev.Namespace;

public interface IAppDbContext
{
    #if (aggregateName != "")
    public {Aggregate} {Aggregate}s { get; }
    #endif

    Task<bool> Commit(CancellationToken cancellationToken = default);
}