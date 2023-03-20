namespace PublicAPI.Rest;

/// <summary>
/// Base class used by API requests
/// </summary>
public abstract class BaseMessage
{
    public Guid CorrelationId { get; set; }
}
