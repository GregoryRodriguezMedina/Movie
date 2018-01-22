using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnCore.Movie.Identity
{
    public static class Bootstrap
    {
        public static void AddIdentity(this IServiceCollection services)
        {
           
            services.AddScoped<UserService, UserService>();
        }
    }
}
