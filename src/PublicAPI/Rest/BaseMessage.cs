namespace PublicAPI.Rest;

/// <summary>
/// Base class used by API requests
/// </summary>
public abstract class BaseMessage
{
    /// <summary>
    /// Unique Identifier used by logging
    /// </summary>
    protected Guid correlationId = Guid.NewGuid();
    
    public Guid CorrelationId() => this.correlationId;
}
