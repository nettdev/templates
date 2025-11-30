namespace ProjectNameOverride.Domain.NameOverrideAggregate;

public sealed class NameOverride : AggregateRoot
{
    public string Name { get; private set; }
    #if (ValueObjectOverride != "")
    public ValueObjectOverride ValueObjectOverride { get; private set; }
    #endif
    #if (EnumerationOverride != "")
    public EnumerationOverride EnumerationOverride { get; private set; }
    #endif

    #if (ValueObjectOverride != "" && EnumerationOverride != "")
    public static Result<NameOverride, Error> Create(Guid id, string name, ValueObjectOverride ValueObjectFieldOverride, EnumerationOverride EnumerationFieldOverride)
    {
        return ParameterRuleBuilder
            .RuleFor(() => name).NotEmpty()
            .Build(() => new NameOverride { Id = id, Name = name, ValueObjectOverride = ValueObjectFieldOverride, EnumerationOverride = EnumerationFieldOverride });
    }
    #elif (ValueObjectOverride != "")
    public static Result<NameOverride, Error> Create(Guid id, string name, ValueObjectOverride ValueObjectFieldOverride)
    {
        return ParameterRuleBuilder
            .RuleFor(() => name).NotEmpty()
            .Build(() => new NameOverride { Id = id, Name = name, ValueObjectOverride = ValueObjectFieldOverride });
    }
    #elif (EnumerationOverride != "")
    public static Result<NameOverride, Error> Create(Guid id, string name, EnumerationOverride EnumerationFieldOverride)
    {
        return ParameterRuleBuilder
            .RuleFor(() => name).NotEmpty()
            .Build(() => new NameOverride { Id = id, Name = name, EnumerationOverride = EnumerationFieldOverride });
    }
    #else
    public static Result<NameOverride, Error> Create(Guid id, string name)
    {
        return ParameterRuleBuilder
            .RuleFor(() => name).NotEmpty()
            .Build(() => new NameOverride { Id = id, Name = name });
    }
    #endif

    #nullable disable
    [ExcludeFromCodeCoverage] private NameOverride() { }
}
