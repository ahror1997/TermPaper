using Microsoft.EntityFrameworkCore;
using TermPaper.Api.AppSettings;
using TermPaper.Api.Data;
using TermPaper.Shared.Settings;

namespace TermPaper.Api.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = Settings.Load<DbSettings>("Database", configuration);
            services.AddSingleton(settings);

            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(settings.ConnectionString));

            return services;
        }
    }
}
