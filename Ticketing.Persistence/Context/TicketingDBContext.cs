using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ticketing.Persistence.Entities;
using Ticketing.Persistence.TypeBuilders;

#nullable disable

namespace Ticketing.Persistence.Context
{
    public class TicketingDBContext : DbContext
    {
        public const string DEFAULT_DATABASE_SCHEMA = "Ticketing";
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<GeneralAdmission> GeneralAdmissions { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<GeneralAdmissionTicket> GeneralAdmissionTickets { get; set; }
        public virtual DbSet<SeatTicket> SeatTickets { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }

        private static readonly Dictionary<Type, Type> TypeBuilders = new Dictionary<Type, Type>();

        public TicketingDBContext()
        {
        }

        public TicketingDBContext(DbContextOptions<TicketingDBContext> options) : base(options)
        {
        }

        private static void RegisterTypeBuilder<TEntity, TBuilder>(ModelBuilder modelBuilder) where TBuilder : BaseTypeBuilder<TEntity>, new() where TEntity : class
        {
            var typeBuilder = modelBuilder.Entity<TEntity>();
            TypeBuilders[typeof(TEntity)] = typeof(TBuilder);
            new TBuilder().Configure(typeBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DEFAULT_DATABASE_SCHEMA);

            RegisterTypeBuilder<Event, EventTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<GeneralAdmission, GeneralAdmissionTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Offer, OfferTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Seat, SeatTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<GeneralAdmissionTicket, GeneralAdmissionTicketTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<SeatTicket, SeatTicketTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Venue, VenueTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Zone, ZoneTypeBuilder>(modelBuilder);

            foreach (IMutableEntityType type in modelBuilder.Model.GetEntityTypes())
            {
                type.SetTableName(type.DisplayName());
            }
        }
    }
}
