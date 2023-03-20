namespace SampleAPI.Rest.Response;

using System.Text.Json;

public class ErrorDetails
{
    public int StatusCode { get; set; }

    public string? Message { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
