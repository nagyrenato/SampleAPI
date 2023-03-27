namespace PublicAPI.Rest;

/// <summary>
/// Base class used by API requests.
/// </summary>
public abstract class BaseMessage
{
    /// <summary>
    /// Gets or sets the correlation id of the message. Used for tracing.
    /// </summary>
    public Guid CorrelationId { get; set; }
}
