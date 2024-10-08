namespace FinBTech.Api.DTOs.Requests.Data;

public record SaveDataRequest
{
    [FromQuery(Name = "entries")]
    [Required(ErrorMessage = "Entries is required.")]
    public IEnumerable<DataEntry>? Entries { get; init; }
}