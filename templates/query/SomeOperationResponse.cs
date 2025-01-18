namespace NettDev.Namespace;

public sealed record SomeOperationResponse
{
    public static SomeOperationResponse Create(AggregateName AggregateNameVar) =>
        new AggregateName();
}
