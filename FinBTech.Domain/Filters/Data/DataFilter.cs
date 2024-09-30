namespace FinBTech.Domain.Filters.Data;

public class DataFilter(int? id, int? code, string? value)
{
    public int? Id { get; } = id;
    public int? Code { get; } = code;
    public string? Value { get; } = value;
}