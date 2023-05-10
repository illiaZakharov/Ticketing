using Microsoft.EntityFrameworkCore;
using Ticketing.Persistence;
using Ticketing.Persistence.Context;

namespace Ticketing.WebApi
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
            TicketingPersistenceModule.RegisterPersistenceModule(
                services,
                options =>
                {
                    options.UseNpgsql(
                        _configuration.GetConnectionString("TicketingDBConnectionString"),
                        assembly =>
                        {
                            assembly.MigrationsHistoryTable("__EFMigrationsHistory", TicketingPersistenceModule.DefaultDBSchema);
                            assembly.MigrationsAssembly("Ticketing.Persistence");
                        }
                    );
                }
            );

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TicketingDBContext dbContext)
        {
            dbContext.Database.Migrate();
        }
    }
}
