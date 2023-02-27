using FluentValidation.AspNetCore;
using System.Reflection;

namespace TermPaper.Api.Configuration
{
    public static class FluentValidatorConfiguration
    {
        public static IServiceCollection AddAppValidator(this IServiceCollection services)
        {
           services.AddFluentValidation(fv =>
            {
                fv.AutomaticValidationEnabled = true;
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
