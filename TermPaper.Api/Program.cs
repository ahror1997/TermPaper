using TermPaper.Api.Configuration;
using TermPaper.Api.Services.AuthService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddControllers();
services.AddAppDbContext(builder.Configuration);
services.AddAppAuth();
services.AddAppValidator();
services.AddAppAutoMappers();

services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
