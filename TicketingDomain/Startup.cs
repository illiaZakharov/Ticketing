using Microsoft.EntityFrameworkCore;
using TicketingDomain.Data;

namespace TicketingDomain
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TicketingDomainContext>(options =>
            {
                options
                    .UseNpgsql(_configuration.GetConnectionString("TicketingDomainConnectionString"),
                        assembly =>
                            assembly.MigrationsAssembly("TicketingDomain.Data"));
            });

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TicketingDomainContext dbContext)
        {
            dbContext.Database.Migrate();
        }
    }
}
