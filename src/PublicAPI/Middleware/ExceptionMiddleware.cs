namespace PublicAPI.Middleware;

using System.Net;
using PublicAPI.Rest.Response;

/// <summary>
/// Middleware for catching exeptions.
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
    /// </summary>
    /// <param name="next">Following delegate.</param>
    public ExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    /// <summary>
    /// Forwards the http call to the destination.
    /// </summary>
    /// <param name="httpContext">Given HTTP context.</param>
    /// <returns><see cref="Task"/>.</returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await this.next(httpContext);
        }
        catch (Exception ex)
        {
            await this.HandleExceptionAsync(httpContext, ex);
        }
    }

    /// <summary>
    /// Handles the case when an exception is being thrown during a request execution.
    /// </summary>
    /// <param name="context">Given HTTP context.</param>
    /// <param name="exception">Given exception.</param>
    /// <returns><see cref="Task"/>.</returns>
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message,
        }.ToString());
    }
}
