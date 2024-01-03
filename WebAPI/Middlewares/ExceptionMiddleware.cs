using System.Net;
using PresentationLayer;

namespace WebAPI;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext httpContext, IHostEnvironment env)
    {
        var originalBodyStream = httpContext.Response.Body;
        await using var responseBody = new MemoryStream();
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex, env);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext context, Exception ex, IHostEnvironment env)
    {
        await context.Response.WriteAsync(new Response
            {
                Ok = false,
                Message = ex.Message,
                ErrorId = Guid.NewGuid().ToString(),
                Errors = null
            }.ToString());
    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}
