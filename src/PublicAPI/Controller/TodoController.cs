namespace PublicAPI.Controller;

using Microsoft.AspNetCore.Mvc;
using PublicAPI.Model;
using PublicAPI.Rest.Request;
using PublicAPI.Service.Interface;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> logger;

    private readonly ITodoService todoService;

    public TodoController(ILogger<TodoController> logger, ITodoService todoService)
    {
        this.logger = logger;
        this.todoService = todoService;
    }

    [HttpGet(Name = "GetTodos")]
    public async Task<IEnumerable<TodoItem>> GetTodosAsync()
    {
        return await this.todoService.GetTodosAsync();
    }

    [HttpPost(Name = "PostTodo")]
    public async Task PostTodoAsync(AddTodoItemRequest request)
    {
        await this.todoService.AddTodoAsync(request);
    }

    [HttpDelete(Name = "DeleteTodo")]
    public async Task DeleteTodoAsync(long id)
    {
        await this.todoService.DeleteTodoAsync(id);
    }
}
