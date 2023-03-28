namespace PublicAPI.Repository.Implementation;

using Microsoft.EntityFrameworkCore;
using PublicAPI.Context;
using PublicAPI.Model;
using PublicAPI.Rest.Request;
using PublicAPI.Repository.Interface;

/// <inheritdoc/>
public class TodoRepository : ITodoRepository
{
    private readonly TodoContext todoContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="TodoRepository"/> class.
    /// </summary>
    /// <param name="todoContext"><see cref="DbContext"/> for <see cref="TodoItem"/> elements.</param>
    public TodoRepository(TodoContext todoContext)
    {
        this.todoContext = todoContext;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TodoItem>> GetTodosAsync()
    {
        return await this.todoContext.TodoItems.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task AddTodoAsync(AddTodoItemRequest request)
    {
        TodoItem item = new TodoItem(request.Id, request.Name, request.IsComplete);
        await this.todoContext.AddAsync<TodoItem>(item);
        await this.todoContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task DeleteTodoAsync(long id)
    {
        TodoItem? item = await this.todoContext.FindAsync<TodoItem>(id);
        if (item != null)
        {
            this.todoContext.Remove(item);
            await this.todoContext.SaveChangesAsync();
        }
    }

    /// <inheritdoc/>
    public async Task GenerateErrorAsync()
    {
        throw new NotImplementedException();
    }
}
