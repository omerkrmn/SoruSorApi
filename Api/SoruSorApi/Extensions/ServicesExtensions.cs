using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;


namespace SoruSorApi.Extensions
{
    static public class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration)=>
            services.AddDbContext<RepositoryContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        
        public static void ConfigRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager,RepositoryManager>();

        public static void ConfigServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
    }
}
