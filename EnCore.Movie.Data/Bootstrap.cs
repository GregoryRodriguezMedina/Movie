using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnCore.Movie.Data
{
    public static class Bootstrap
    {
        public static void AddData(this IServiceCollection services)
        {
            services.AddScoped<DbContext, MovieDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IRentalDetailRepository, RentalDetailRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
        }
    }
}
