using DesafioSky.Data;
using DesafioSky.Services;


var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);

var app = builder.Build();

app.MapControllers();

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<AppDbContext>();   
    builder.Services.AddTransient<EmailService>();
}

