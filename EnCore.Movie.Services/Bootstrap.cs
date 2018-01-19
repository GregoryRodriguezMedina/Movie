using Microsoft.Extensions.DependencyInjection;

namespace EnCore.Movie.Services
{
    public static class Bootstrap
    {
        public static void AddServices(this IServiceCollection services)
        {
            //TODO: modificar al momento de definir las interfaces
            services.AddScoped<CustomerService, CustomerService>();
            services.AddScoped<MovieService, MovieService>();
            services.AddScoped<RentalService, RentalService>();
        }
    }
}
