namespace NettDev.Namespace;

public sealed class EnumerationName(string name, int value, string description) : Enumeration<EnumerationName>(name, value)
{
    private static readonly Dictionary<int, ReservationStatus> _values = new()
    {
        { 0, new(name: nameof(None), value: 0, description: "Empty") }
    };

    public static EnumerationName None => _values[0];

    public string Description => description;

    public static EnumerationName? FromNumber(int id) =>
        _values.TryGetValue(id, out var value) ? value : null;

    public static EnumerationName? FromName(string name) =>
        _values.FirstOrDefault(x => x.Value.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).Value;

    public static IEnumerable<EnumerationName> GetAll() =>
        _values.Select(x => x.Value);
}
