using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebAPI;

public class AuthOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        // operation.Parameters.Add(new OpenApiParameter
        // {
        //     Name = "RecaptchaToken",
        //     In = ParameterLocation.Header,
        //     Schema = new OpenApiSchema { Type = "String" },
        //     Required = false
        // });

        var allowAnonymous = context.ApiDescription.CustomAttributes()
            .Any(a => a.GetType() == typeof(AllowAnonymousAttribute));
        if (allowAnonymous) return;

        operation.Security = new List<OpenApiSecurityRequirement>
        {
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            }
        };
    }
}
