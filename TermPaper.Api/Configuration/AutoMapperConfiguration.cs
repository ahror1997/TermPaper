namespace TermPaper.Api.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAppAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
            return services;
        }
    }
}
