namespace FinBTech.Domain.Filters;

public abstract class PaginationFilter
{
    public int? Offset { get; init; }

    public int Limit { get; init; }

    public PaginationFilter(int? offset, int limit)
    {
        if (offset is not null and < 1)
            throw new DomainException("Offset cannot be negative.");

        if (limit <= 0)
            throw new DomainException("Limit must be greater than zero.");

        (Offset, Limit) = (offset, limit);
    }
}