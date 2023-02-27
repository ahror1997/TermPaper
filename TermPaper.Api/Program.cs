using TermPaper.Api.Configuration;
using TermPaper.Api.Services.AuthService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddControllers();
services.AddRouting(options => options.LowercaseUrls = true);
services.AddAppDbContext(builder.Configuration);
services.AddAppAuth();
services.AddAppValidator();
services.AddAppSwagger();
services.AddAppAutoMappers();

services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.UseAppSwagger();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
