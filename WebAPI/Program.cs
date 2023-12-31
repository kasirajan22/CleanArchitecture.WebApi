using WebAPI;

var builder = WebApplication.CreateBuilder(args).ConfigureBuilder();

var app = builder.Build().ConfigureApplication();

app.Run();

public partial class Program 
{
    
}