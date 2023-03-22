namespace PublicAPI.Repository.Implementation;

using Microsoft.EntityFrameworkCore;
using PublicAPI.Context;
using PublicAPI.Model;
using PublicAPI.Rest.Request;
using PublicAPI.Repository.Interface;

public class TodoRepository : ITodoRepository
{
    private readonly ILogger<ITodoRepository> logger;

    private readonly TodoContext todoContext;

    public TodoRepository(ILogger<TodoRepository> logger, TodoContext todoContext)
    {
        this.logger = logger;
        this.todoContext = todoContext;
    }

    public async Task<IEnumerable<TodoItem>> GetTodosAsync()
    {
        this.logger.LogInformation("GetTodos is being called");
        return await this.todoContext.TodoItems.ToListAsync();
    }

    public async Task AddTodoAsync(AddTodoItemRequest request)
    {
        this.logger.LogInformation("PostTodoAsync is being called");
        TodoItem item = new TodoItem(request.Id, request.Name, request.IsComplete);
        await this.todoContext.AddAsync<TodoItem>(item);
        await this.todoContext.SaveChangesAsync();
    }

    public async Task DeleteTodoAsync(long id)
    {
        this.logger.LogInformation("DeleteTodo is being called");
        TodoItem? item = await this.todoContext.FindAsync<TodoItem>(id);
        if (item != null)
        {
            this.todoContext.Remove(item);
            await this.todoContext.SaveChangesAsync();
        }
    }
}
