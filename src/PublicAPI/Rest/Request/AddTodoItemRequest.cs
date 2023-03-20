namespace PublicAPI.Rest.Request;

public class AddTodoItemRequest : BaseRequest
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public bool IsComplete { get; set; }
}
