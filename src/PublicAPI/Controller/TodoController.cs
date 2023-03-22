namespace PublicAPI.Controller;

using Microsoft.AspNetCore.Mvc;
using PublicAPI.Model;
using PublicAPI.Rest.Request;
using PublicAPI.Repository.Interface;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> logger;

    private readonly ITodoRepository todoRepository;

    public TodoController(ILogger<TodoController> logger, ITodoRepository todoRepository)
    {
        this.logger = logger;
        this.todoRepository = todoRepository;
    }

    [HttpGet(Name = "GetTodos")]
    public async Task<IEnumerable<TodoItem>> GetTodosAsync()
    {
        return await this.todoRepository.GetTodosAsync();
    }

    [HttpPost(Name = "PostTodo")]
    public async Task PostTodoAsync(AddTodoItemRequest request)
    {
        await this.todoRepository.AddTodoAsync(request);
    }

    [HttpDelete(Name = "DeleteTodo")]
    public async Task DeleteTodoAsync(long id)
    {
        await this.todoRepository.DeleteTodoAsync(id);
    }
}
