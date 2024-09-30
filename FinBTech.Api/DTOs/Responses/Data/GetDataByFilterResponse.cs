namespace FinBTech.Api.DTOs.Responses.Data;

public class GetDataByFilterResponse
{
    public IEnumerable<DataEntry> Entries { get; set; } = [];
}