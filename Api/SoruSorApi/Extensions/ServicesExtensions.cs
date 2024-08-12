using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using System.Text;


namespace SoruSorApi.Extensions
{
    static public class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                //for password
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                //for mail
                options.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                };
            });
        }
    }
}
