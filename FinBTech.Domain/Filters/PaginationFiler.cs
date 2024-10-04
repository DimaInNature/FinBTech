namespace FinBTech.Domain.Filters;

public class PaginationFiler
{
    public int Offset { get; set; }

    public int Limit { get; set; } = 1;
}