using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserSearchApp.Data.Context;
using UserSearchApp.Data.Repositories;
using UserSearchApp.Services.ApiClients;
using UserSearchApp.Services.AppMapper;
using UserSearchApp.Services.Services;

namespace UserSearchApp.Services
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ApplicationMapper));

            services.AddHttpClient("JsonPlaceHolderApiClient", o => {
                o.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            });

            var conString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                                options.UseNpgsql(conString));

            services.AddTransient<UserService>();
            services.AddTransient<UserRepository>();
            services.AddTransient<IJsonPlaceholderApiClient, JsonPlaceholderApiClient>();
        }
    }
}
