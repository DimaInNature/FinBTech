namespace FinBTech.Domain.Models.Data;

public class DataEntry
{
    public int Code { get; private set; }
    public string Value { get; private set; }

    public DataEntry(int code, string value)
    {
        Validate(code, value);

        (Code, Value) = (code, value);
    }

    private void Validate(int code, string value)
    {
        if (code < 0)
            throw new DomainException("Code cannot be negative.");

        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Value cannot be null or whitespace.");
    }
}