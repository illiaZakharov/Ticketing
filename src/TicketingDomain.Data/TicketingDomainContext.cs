using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TicketingDomain.Data.Entities;
using TicketingDomain.Data.TypeBuilders;

namespace TicketingDomain.Data
{
    public class TicketingDomainContext : DbContext
    {
        public const string DEFAULT_DATABASE_SCHEMA = "TicketingDomain";
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventCategory> EventCategories { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Row> Rows { get; set; }
        public virtual DbSet<RowSeat> RowSeats { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<VenueCategory> VenueCategories { get; set; }
        public virtual DbSet<Row> VenueRows{ get; set; }
        public virtual DbSet<VenueVenueCategory> VenueVenueCategories { get; set; }

        private static readonly Dictionary<Type, Type> TypeBuilders = new Dictionary<Type, Type>();

        public TicketingDomainContext() 
        {
        }

        public TicketingDomainContext(DbContextOptions options) : base(options)
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

            RegisterTypeBuilder<Address, AddressTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<EventCategory, EventCategoryTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<EventEventCategory, EventEventCategoryTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Event, EventTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Payment, PaymentTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<RowSeat, RowSeatTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Row, RowTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Seat, SeatTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Ticket, TicketTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<UserRole, UserRoleTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<User, UserTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<VenueCategory, VenueCategoryTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<VenueRow, VenueRowTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<Venue, VenueTypeBuilder>(modelBuilder);
            RegisterTypeBuilder<VenueVenueCategory, VenueVenueCategoryTypeBuilder>(modelBuilder);

            foreach (IMutableEntityType type in modelBuilder.Model.GetEntityTypes()) 
            {
                type.SetTableName(type.DisplayName());
            }
        }
    }
}
