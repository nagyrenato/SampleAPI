namespace PublicAPI.Rest.Request;

using PublicAPI.Model;
using System;

/// <summary>
/// Rest request for adding <see cref="TodoItem"/>.
/// </summary>
public class AddTodoItemRequest : BaseRequest
{
    /// <summary>
    /// Gets or sets the id of the element.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the element.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the element is completed or not.
    /// </summary>
    public bool IsComplete { get; set; }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is AddTodoItemRequest request &&
               this.CorrelationId.Equals(request.CorrelationId) &&
               this.Id == request.Id &&
               this.Name == request.Name &&
               this.IsComplete == request.IsComplete;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.CorrelationId, this.Id, this.Name, this.IsComplete);
    }
}
