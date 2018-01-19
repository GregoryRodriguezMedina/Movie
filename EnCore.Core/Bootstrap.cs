using Microsoft.Extensions.DependencyInjection;

namespace EnCore.Core
{
    public static class Bootstrap
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEfRepositoryBase<>), typeof(EfRepositoryBase<>));
            services.AddScoped(typeof(IEfRepositoryBase<,>), typeof(EfRepositoryBase<,>));

        }
    }
}
