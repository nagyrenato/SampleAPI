namespace PublicAPI.Service.Interface;

using PublicAPI.Model;
using PublicAPI.Rest.Request;

public interface ITodoService
{
    public Task<IEnumerable<TodoItem>> GetTodosAsync();

    public Task AddTodoAsync(AddTodoItemRequest request);

    public Task DeleteTodoAsync(long id);
}
