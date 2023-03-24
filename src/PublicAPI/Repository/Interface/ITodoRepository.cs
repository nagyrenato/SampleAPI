namespace PublicAPI.Repository.Interface;

using PublicAPI.Model;
using PublicAPI.Rest.Request;

/// <summary>
/// Repository to manage <see cref="TodoItem"/> elements.
/// </summary>
public interface ITodoRepository
{
    /// <summary>
    /// Get all <see cref="TodoItem"/> elements.
    /// </summary>
    /// <returns>A list of <see cref="TodoItem"/>s.</returns>
    public Task<IEnumerable<TodoItem>> GetTodosAsync();

    /// <summary>
    /// Adds a new <see cref="TodoItem"/> to the store.
    /// TODO: It might be better to not wait rest request here.
    /// </summary>
    /// <param name="request">A <see cref="AddTodoItemRequest"/> that contains all the necessary parameters.</param>
    /// <returns><see cref="Task"/>.</returns>
    public Task AddTodoAsync(AddTodoItemRequest request);

    /// <summary>
    /// Deletes a <see cref="TodoItem"/> based on the given id.
    /// </summary>
    /// <param name="id">The id of the <see cref="TodoItem"/> element that must be deleted.</param>
    /// <returns><see cref="Task"/>.</returns>
    public Task DeleteTodoAsync(long id);
}
