namespace FinBTech.Api.DTOs.Responses.Data;

public record GetDataByFilterResponse
{
    public IEnumerable<DataEntry> Entries { get; init; }

    public GetDataByFilterResponse(IEnumerable<DataEntry> entries) => Entries = entries;
}