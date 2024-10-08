namespace FinBTech.Api.DTOs.Responses.Data;

public record GetDataByFilterResponse
{
    public required IEnumerable<DataEntry> Entries { get; init; }
}