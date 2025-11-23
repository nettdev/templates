namespace ProjectNameOverride.Domain.NameOverrideAggregate;

public sealed class EnumerationOverride(string name, int value, string description) : Enumeration<EnumerationOverride>(name, value)
{
    private static readonly List<EnumerationOverride> _values =
    [
        new(name: nameof(None), value: 0, description: "Empty")
    ];

    public static EnumerationOverride None => _values[0];

    public string Description => description;

    public static EnumerationOverride? FromNumber(int id) =>
        _values.FirstOrDefault(x => x.Value == id);

    public static EnumerationOverride? FromName(string name) =>
        _values.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public static EnumerationOverride? FromDescription(string description) =>
        _values.FirstOrDefault(x => x.Description.Equals(description, StringComparison.OrdinalIgnoreCase));

    public static IEnumerable<EnumerationOverride> GetAll() =>
        _values;
}
