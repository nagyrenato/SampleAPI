﻿namespace PublicAPI.Models;

using Microsoft.AspNetCore.Mvc;

[ApiExplorerSettings(IgnoreApi=true)]
public class TodoItem
{
    public TodoItem(long id, string? name, bool isComplete)
    {
        this.Id = id;
        this.Name = name;
        this.IsComplete = isComplete;
    }

    public long Id { get; set; }

    public string? Name { get; set; }

    public bool IsComplete { get; set; }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is TodoItem item &&
               this.Id == item.Id &&
               this.Name == item.Name &&
               this.IsComplete == item.IsComplete;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id, this.Name, this.IsComplete);
    }
}