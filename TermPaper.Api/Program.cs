using TermPaper.Api.Configuration;
using TermPaper.Api.Services.AuthService;
using TermPaper.Api.Services.OrderService;
using TermPaper.Api.Services.TokenService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddControllers();
services.AddRouting(options => options.LowercaseUrls = true);
services.AddAppDbContext(builder.Configuration);
services.AddAppAuth(builder.Configuration);
services.AddAppValidator();
services.AddAppSwagger();
services.AddAppAutoMappers();

services.AddScoped<IAuthService, AuthService>();
services.AddScoped<ITokenService, TokenService>();
services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

app.UseAppSwagger();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
