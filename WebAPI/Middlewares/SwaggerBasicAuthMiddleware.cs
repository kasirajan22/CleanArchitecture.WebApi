using System.Net;
using System.Text;

namespace WebAPI;

public class SwaggerBasicAuthMiddleware
{
    private readonly RequestDelegate next;

    public SwaggerBasicAuthMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            string? authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword!));

                var username = decodedUsernamePassword.Split(':', 2)[0];
                var password = decodedUsernamePassword.Split(':', 2)[1];

                if (username.Equals("Admin", StringComparison.InvariantCultureIgnoreCase) && password.Equals("test1234"))
                {
                    await next.Invoke(context);
                    return;
                }
            }
            context.Response.Headers["WWW-Authenticate"] = "Basic";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            await next.Invoke(context);
        }
    }
}

public static class SwaggerAuthorizeExtensions
{
    public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SwaggerBasicAuthMiddleware>();
    }
}
