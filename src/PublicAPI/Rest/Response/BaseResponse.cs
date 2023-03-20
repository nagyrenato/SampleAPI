namespace PublicAPI.Rest.Response;

/// <summary>
/// Base class used by API responses
/// </summary>
public abstract class BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlationId)
        : base()
    {
        this.CorrelationId = correlationId;
    }

    public BaseResponse()
    {
    }
}
