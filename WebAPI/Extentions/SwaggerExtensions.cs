using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebAPI;

public static class SwaggerExtensions
{
    public static void ConfigureSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Clean Architecture Core Api",
                Description = "Web Api(s)",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Support",
                    Email = "support@gmail.com",
                    Url = new Uri("https://www.google.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Clean License",
                    Url = new Uri("https://www.google.com/license")
                }
            });
            // var xmlPath = Path.Combine(AppContext.BaseDirectory, "OpenApiDoc.xml");
            // c.IncludeXmlComments(xmlPath);

            c.CustomOperationIds(o =>
            {
                return o.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name.Replace("Async", "") : null;
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });
        });
    }
}
