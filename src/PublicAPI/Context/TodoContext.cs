namespace PublicAPI.Context;

using Microsoft.EntityFrameworkCore;
using PublicAPI.Model;

/// <summary>
/// Context for <see cref="TodoItem"/>.
/// </summary>
public class TodoContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TodoContext"/> class.
    /// </summary>
    /// <param name="options">Optional <see cref="DbContextOptions"/> to customize the context.</param>
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Dataset for <see cref="TodoItem"/> items.
    /// </summary>
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}
