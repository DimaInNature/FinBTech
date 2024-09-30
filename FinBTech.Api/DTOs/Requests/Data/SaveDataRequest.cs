namespace FinBTech.Api.DTOs.Requests.Data;

public class SaveDataRequest
{
    public IEnumerable<DataEntry>? Entries { get; set; }
}