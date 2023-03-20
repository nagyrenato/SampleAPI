namespace SampleAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Rest.Request;
using TodoApi.Contexts;
using TodoApi.Models;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> logger;

    private readonly TodoContext todoContext;

    public TodoController(ILogger<TodoController> logger, TodoContext todoContext)
    {
        this.logger = logger;
        this.todoContext = todoContext;
    }

    [HttpGet(Name = "GetTodos")]
    public async Task<IEnumerable<TodoItem>> GetTodosAsync()
    {
        this.logger.LogInformation("GetTodos is being called");
        return await this.todoContext.TodoItems.ToListAsync();
    }

    [HttpPost(Name = "PostTodo")]
    public async Task PostTodoAsync(AddTodoItemRequest request)
    {
        this.logger.LogInformation("PostTodoAsync is being called");
        TodoItem item = new TodoItem(request.Id, request.Name, request.IsComplete);
        await this.todoContext.AddAsync<TodoItem>(item);
        await this.todoContext.SaveChangesAsync();
    }

    [HttpDelete(Name = "DeleteTodo")]
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
