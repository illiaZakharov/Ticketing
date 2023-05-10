using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ticketing");

            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "Ticketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    EventDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(now())"),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValueSql: "(current_user)"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                schema: "Ticketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(now())"),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValueSql: "(current_user)"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                schema: "Ticketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VenueId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(now())"),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValueSql: "(current_user)"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "Ticketing",
                        principalTable: "Event",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offer_Venue_VenueId",
                        column: x => x.VenueId,
                        principalSchema: "Ticketing",
                        principalTable: "Venue",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                schema: "Ticketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VenueId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(now())"),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValueSql: "(current_user)"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zone_Venue_VenueId",
                        column: x => x.VenueId,
                        principalSchema: "Ticketing",
                        principalTable: "Venue",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneralAdmission",
                schema: "Ticketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    MaxQuantity = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(now())"),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValueSql: "(current_user)"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralAdmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralAdmission_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Ticketing",
                        principalTable: "Zone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                schema: "Ticketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    SeatNumber = table.Column<int>(type: "integer", nullable: false),
                    RowNumber = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(now())"),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValueSql: "(current_user)"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Ticketing",
                        principalTable: "Zone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneralAdmissionTicket",
                schema: "Ticketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GeneralAdmissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(now())"),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValueSql: "(current_user)"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralAdmissionTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralAdmissionTicket_GeneralAdmission_GeneralAdmissionId",
                        column: x => x.GeneralAdmissionId,
                        principalSchema: "Ticketing",
                        principalTable: "GeneralAdmission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeneralAdmissionTicket_Offer_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "Ticketing",
                        principalTable: "Offer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeatTicket",
                schema: "Ticketing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SeatId = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(now())"),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValueSql: "(current_user)"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatTicket_Offer_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "Ticketing",
                        principalTable: "Offer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeatTicket_Seat_SeatId",
                        column: x => x.SeatId,
                        principalSchema: "Ticketing",
                        principalTable: "Seat",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAdmission_ZoneId",
                schema: "Ticketing",
                table: "GeneralAdmission",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAdmissionTicket_GeneralAdmissionId",
                schema: "Ticketing",
                table: "GeneralAdmissionTicket",
                column: "GeneralAdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAdmissionTicket_OfferId",
                schema: "Ticketing",
                table: "GeneralAdmissionTicket",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_EventId",
                schema: "Ticketing",
                table: "Offer",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_VenueId",
                schema: "Ticketing",
                table: "Offer",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ZoneId",
                schema: "Ticketing",
                table: "Seat",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatTicket_OfferId",
                schema: "Ticketing",
                table: "SeatTicket",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatTicket_SeatId",
                schema: "Ticketing",
                table: "SeatTicket",
                column: "SeatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zone_VenueId",
                schema: "Ticketing",
                table: "Zone",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralAdmissionTicket",
                schema: "Ticketing");

            migrationBuilder.DropTable(
                name: "SeatTicket",
                schema: "Ticketing");

            migrationBuilder.DropTable(
                name: "GeneralAdmission",
                schema: "Ticketing");

            migrationBuilder.DropTable(
                name: "Offer",
                schema: "Ticketing");

            migrationBuilder.DropTable(
                name: "Seat",
                schema: "Ticketing");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "Ticketing");

            migrationBuilder.DropTable(
                name: "Zone",
                schema: "Ticketing");

            migrationBuilder.DropTable(
                name: "Venue",
                schema: "Ticketing");
        }
    }
}
