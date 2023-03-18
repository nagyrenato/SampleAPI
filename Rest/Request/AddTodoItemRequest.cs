namespace SampleAPI.Rest.Request;

public class AddTodoItemRequest
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public bool IsComplete { get; set; }
}