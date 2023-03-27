namespace PublicAPI.Rest.Response;

using System.Text.Json;
using PublicAPI.Middleware;

/// <summary>
/// Message if an error is being thrown in the application.
/// Used by <see cref="ExceptionMiddleware"/>.
/// </summary>
public class ErrorDetails
{
    /// <summary>
    /// Gets or sets the status code for the error.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets the text message of the error.
    /// </summary>
    public string? Message { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
