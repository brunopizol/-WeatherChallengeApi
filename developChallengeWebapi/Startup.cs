using developChallenge.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace developChallenge.Web.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Other configurations...
            //sql server
            //var connectionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<MyDatabaseContext>(options =>
            //    options.UseSqlServer(connectionString));

            //MySQL
            string connectionString = "server=localhost;port=3306;database=brasilapi;user=root;password=testedev12345";
            services.AddDbContext<MyDatabaseContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );



            // Other configurations...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
