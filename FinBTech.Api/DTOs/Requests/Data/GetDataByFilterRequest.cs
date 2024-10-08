namespace FinBTech.Api.DTOs.Requests.Data;

public record GetDataByFilterRequest
{
    [FromQuery(Name = "id")] public int? Id { get; init; }

    [FromQuery(Name = "code")] public int? Code { get; init; }

    [FromQuery(Name = "value")] public string? Value { get; init; }

    [FromQuery(Name = "offset")] public int? Offset { get; init; }

    [FromQuery(Name = "limit")] 
    [Required(ErrorMessage = "Limit is required.")] 
    public int Limit { get; init; }
}