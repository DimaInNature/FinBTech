namespace FinBTech.Domain.Filters.Data;

public class DataFilter(int? id, int? code, string? value, int? offset, int limit) 
    : PaginationFilter(offset, limit)
{
    public int? Id { get; } = id;
    public int? Code { get; } = code;
    public string? Value { get; } = value;
}