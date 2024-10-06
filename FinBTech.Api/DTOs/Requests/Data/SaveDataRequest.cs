namespace FinBTech.Api.DTOs.Requests.Data;

public class SaveDataRequest
{
    [FromQuery(Name = "entries")]
    [Required(ErrorMessage = "Entries is required.")]
    public IEnumerable<DataEntry>? Entries { get; set; }
}