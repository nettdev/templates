namespace NettDev.Namespace;

public sealed record SomeOperationResponse
{
    public static SomeOperationResponse Create({Aggregate} aggregate) =>
        new();
}
