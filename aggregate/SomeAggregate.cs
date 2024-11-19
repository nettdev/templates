namespace NettDev.Namespace;

public sealed class SomeAggregate : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    #if (valueObjectName != "")
    public SomeValueObject SomeValueObject { get; private set; }
    #endif
    #if (enumerationName != "")
    public SomeEnumeration SomeEnumeration { get; private set; }
    #endif

    #if (valueObjectName != "" && enumerationName != "")
    public SomeAggregate(string name, SomeValueObject valueObjectParameter, SomeEnumeration enumerationParameter)
    {
        Name = name;
        SomeValueObject = valueObjectParameter;
        SomeEnumeration = enumerationParameter;
    }
    #elif (valueObjectName != "")
    public SomeAggregate(string name, SomeValueObject valueObjectParameter)
    {
        Name = name;
        SomeValueObject = valueObjectParameter;
    }
    #elif (enumerationName != "")
    public SomeAggregate(string name, SomeEnumeration enumerationParameter)
    {
        Name = name;
        SomeEnumeration = enumerationParameter;
    }
    #else
    public SomeAggregate(string name)
    {
        Name = name;
    }
    #endif
}
