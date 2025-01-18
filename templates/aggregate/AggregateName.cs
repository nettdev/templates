namespace NettDev.Namespace;

public sealed class AggregateName : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    #if (valueObjectName != "")
    public ValueObjectName ValueObjectName { get; private set; }
    #endif
    #if (enumerationName != "")
    public EnumerationName EnumerationName { get; private set; }
    #endif

    #if (valueObjectName != "" && enumerationName != "")
    public AggregateName(string name, ValueObjectName valueObjectParameter, EnumerationName enumerationParameter)
    {
        Name = name;
        ValueObjectName = valueObjectParameter;
        EnumerationName = enumerationParameter;
    }
    #elif (valueObjectName != "")
    public AggregateName(string name, ValueObjectName valueObjectParameter)
    {
        Name = name;
        ValueObjectName = valueObjectParameter;
    }
    #elif (enumerationName != "")
    public AggregateName(string name, EnumerationName enumerationParameter)
    {
        Name = name;
        EnumerationName = enumerationParameter;
    }
    #else
    public AggregateName(string name)
    {
        Name = name;
    }
    #endif

    #nullable disable
    [ExcludeFromCodeCoverage] private AggregateName() { }
}
