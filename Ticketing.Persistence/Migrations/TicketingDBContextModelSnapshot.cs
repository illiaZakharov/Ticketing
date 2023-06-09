﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ticketing.Persistence.Context;

#nullable disable

namespace Ticketing.Persistence.Migrations
{
    [DbContext(typeof(TicketingDBContext))]
    partial class TicketingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Ticketing")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ticketing.Persistence.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("(current_user)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("ModifiedBy")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Event", "Ticketing");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.GeneralAdmission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("(current_user)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<int>("MaxQuantity")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("text");

                    b.Property<Guid>("ZoneId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ZoneId");

                    b.ToTable("GeneralAdmission", "Ticketing");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.GeneralAdmissionTicket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("(current_user)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("GeneralAdmissionId")
                        .HasColumnType("uuid");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("ModifiedBy")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("text");

                    b.Property<Guid>("OfferId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("GeneralAdmissionId");

                    b.HasIndex("OfferId");

                    b.ToTable("GeneralAdmissionTicket", "Ticketing");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("(current_user)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("ModifiedBy")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.HasIndex("VenueId");

                    b.ToTable("Offer", "Ticketing");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("(current_user)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("ModifiedBy")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("text");

                    b.Property<int>("RowNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("ZoneId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ZoneId");

                    b.ToTable("Seat", "Ticketing");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.SeatTicket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("(current_user)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("ModifiedBy")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("text");

                    b.Property<Guid>("OfferId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("SeatId")
                        .IsUnique();

                    b.ToTable("SeatTicket", "Ticketing");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("(current_user)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("ModifiedBy")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Venue", "Ticketing");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Zone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("(current_user)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("ModifiedBy")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Zone", "Ticketing");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.GeneralAdmission", b =>
                {
                    b.HasOne("Ticketing.Persistence.Entities.Zone", "Zone")
                        .WithMany("GeneralAdmissions")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.GeneralAdmissionTicket", b =>
                {
                    b.HasOne("Ticketing.Persistence.Entities.GeneralAdmission", "GeneralAdmission")
                        .WithMany("Tickets")
                        .HasForeignKey("GeneralAdmissionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Ticketing.Persistence.Entities.Offer", "Offer")
                        .WithMany("GeneralAdmissionTickets")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("GeneralAdmission");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Offer", b =>
                {
                    b.HasOne("Ticketing.Persistence.Entities.Event", "Event")
                        .WithOne("Offer")
                        .HasForeignKey("Ticketing.Persistence.Entities.Offer", "EventId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Ticketing.Persistence.Entities.Venue", "Venue")
                        .WithMany("Offers")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Seat", b =>
                {
                    b.HasOne("Ticketing.Persistence.Entities.Zone", "Zone")
                        .WithMany("Seats")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.SeatTicket", b =>
                {
                    b.HasOne("Ticketing.Persistence.Entities.Offer", "Offer")
                        .WithMany("SeatTickets")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Ticketing.Persistence.Entities.Seat", "Seat")
                        .WithOne("Ticket")
                        .HasForeignKey("Ticketing.Persistence.Entities.SeatTicket", "SeatId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Offer");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Zone", b =>
                {
                    b.HasOne("Ticketing.Persistence.Entities.Venue", "Venue")
                        .WithMany("Zones")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Event", b =>
                {
                    b.Navigation("Offer")
                        .IsRequired();
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.GeneralAdmission", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Offer", b =>
                {
                    b.Navigation("GeneralAdmissionTickets");

                    b.Navigation("SeatTickets");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Seat", b =>
                {
                    b.Navigation("Ticket")
                        .IsRequired();
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Venue", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("Ticketing.Persistence.Entities.Zone", b =>
                {
                    b.Navigation("GeneralAdmissions");

                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
