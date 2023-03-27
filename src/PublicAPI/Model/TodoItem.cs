namespace PublicAPI.Model;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Representation of a todo item element.
/// </summary>
public class TodoItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TodoItem"/> class.
    /// </summary>
    /// <param name="id">The id of the element.</param>
    /// <param name="name">The name of the element.</param>
    /// <param name="isComplete">Defines if it is completed or not.</param>
    public TodoItem(long id, string? name, bool isComplete)
    {
        this.Id = id;
        this.Name = name;
        this.IsComplete = isComplete;
    }

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
