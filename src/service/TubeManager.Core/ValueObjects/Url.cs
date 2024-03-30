namespace TubeManager.Core.ValueObjects;

public record Url
{
    public string Value { get; }

    public Url(string value)
    {
        Value = value;
    }

    public static implicit operator string(Url url)
        => url.Value;

    public static implicit operator Url(string value)
        => new(value);
}