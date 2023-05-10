using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ticketing.Persistence.Context;

namespace Ticketing.Persistence
{
    public static class TicketingPersistenceModule
    {
        public static string DefaultDBSchema => TicketingDBContext.DEFAULT_DATABASE_SCHEMA;

        public static void RegisterPersistenceModule(IServiceCollection services, Action<DbContextOptionsBuilder> optionsBilder)
        {
            services.AddDbContext<TicketingDBContext>(optionsBilder);
            services.AddScoped<DbContext, TicketingDBContext>();
        }
    }
}