namespace FinBTech.Domain.Entities;

public class LogEntity
{
    public Guid Id { get; set; }

    public required string RequestUri { get; set; }

    public string? RequestBody { get; set; }

    public required string Response { get; set; }

    public required DateTime Date { get; set; }
}