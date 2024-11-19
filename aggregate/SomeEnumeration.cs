namespace NettDev.Namespace;

public sealed class SomeEnumeration(string name, int value, string description) : Enumeration<SomeEnumeration>(name, value)
{
    private static readonly Dictionary<int, ReservationStatus> _values = new()
    {
        { 0, new(name: nameof(None), value: 0, description: "Empty") }
    };

    public static SomeEnumeration None => _values[0];

    public string Description => description;

    public static SomeEnumeration? FromNumber(int id) =>
        _values.TryGetValue(id, out var value) ? value : null;

    public static SomeEnumeration? FromName(string name) =>
        _values.FirstOrDefault(x => x.Value.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).Value;

    public static IEnumerable<SomeEnumeration> GetAll() =>
        _values.Select(x => x.Value);
}
