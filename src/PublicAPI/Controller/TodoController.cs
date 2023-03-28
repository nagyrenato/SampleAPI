namespace PublicAPI.Controller;

using Microsoft.AspNetCore.Mvc;
using PublicAPI.Model;
using PublicAPI.Rest.Request;
using PublicAPI.Repository.Interface;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// Controller to manage todo items.
/// </summary>
[ApiController]
[Route("api/[controller]s")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> logger;

    private readonly ITodoRepository todoRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="TodoController"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    /// <param name="todoRepository">Repository for <see cref="TodoItem"/> elements.</param>
    public TodoController(ILogger<TodoController> logger, ITodoRepository todoRepository)
    {
        this.logger = logger;
        this.todoRepository = todoRepository;
    }

    /// <summary>
    /// Endpoint to get all todo items elements.
    /// </summary>
    /// <returns>A list of todo items.</returns>
    [SwaggerOperation(
        Summary = "Endpoint to get all todo items elements.",
        Tags = new[] { "TodoItems" })]
    [HttpGet("", Name = "GetTodos")]
    public async Task<IEnumerable<TodoItem>> GetTodosAsync()
    {
        this.logger.LogInformation("GetTodos is getting called");
        return await this.todoRepository.GetTodosAsync();
    }

    /// <summary>
    /// Endpoint to post a new todo element.
    /// </summary>
    /// <param name="request">Rest request to add new todo item.</param>
    /// <returns>Http 200 if successfull.</returns>
    [SwaggerOperation(
        Summary = "Endpoint to post a new todo element.",
        Tags = new[] { "TodoItems" })]
    [HttpPost(Name = "PostTodo")]
    public async Task PostTodoAsync(AddTodoItemRequest request)
    {
        this.logger.LogInformation("PostTodo is getting called");
        await this.todoRepository.AddTodoAsync(request);
    }

    /// <summary>
    /// Endpoint to post new todo elements.
    /// </summary>
    /// <param name="id">The id of the element that must be deleted.</param>
    /// <returns>Http 200 if successfull.</returns>
    [HttpDelete(Name = "{id}")]
    public async Task DeleteTodoAsync(long id)
    {
        this.logger.LogInformation("DeleteTodo is getting called");
        await this.todoRepository.DeleteTodoAsync(id);
    }

    /// <summary>
    /// Endpoint to demonstrate error handling.
    /// </summary>
    /// <returns>Http 500 if successfull.</returns> 
    [HttpGet("error", Name = "ErrorTodoAsync")]
    public async Task<ActionResult> ErrorTodoAsync()
    {
        await this.todoRepository.GenerateErrorAsync();
        return this.Ok(string.Empty);
    }
}
