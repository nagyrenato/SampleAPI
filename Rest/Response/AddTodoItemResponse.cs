﻿namespace SampleAPI.Rest.Response;

public class AddTodoItemResponse
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public bool IsComplete { get; set; }
}
