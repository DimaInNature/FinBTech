namespace FinBTech.Domain.Models.Data;

public class DataEntry(int code, string value)
{
    public int Code { get; } = code;
    public string Value { get; } = value;
}