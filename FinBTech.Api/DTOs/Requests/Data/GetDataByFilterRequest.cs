namespace FinBTech.Api.DTOs.Requests.Data;

public class GetDataByFilterRequest
{
    public int? Id { get; set; }
    public int? Code { get; set; }
    public string? Value { get; set; }

    public int Count { get; set; } = 1;
}