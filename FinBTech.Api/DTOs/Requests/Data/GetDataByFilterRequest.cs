namespace FinBTech.Api.DTOs.Requests.Data;

public class GetDataByFilterRequest
{
    [FromQuery(Name = "id")] public int? Id { get; set; }

    [FromQuery(Name = "code")] public int? Code { get; set; }

    [FromQuery(Name = "value")] public string? Value { get; set; }

    [FromQuery(Name = "offset")] public int? Offset { get; set; }

    [FromQuery(Name = "limit")] public int Limit { get; set; } = 1;
}