using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingDomain.Data.Migrations
{
    /// <inheritdoc />
    public partial class Data_UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
ALTER TABLE ""TicketingDomain"".""UserRole"" ADD CONSTRAINT UQ_UserRole_SeqId UNIQUE (""SeqId"");
INSERT INTO ""TicketingDomain"".""UserRole"" (""Name"", ""Description"", ""SeqId"")
VALUES ('Admin', 'Admin', 1),
       ('Event Manager', 'Event Manager', 2),
       ('Customer', 'Customer', 3)
ON CONFLICT (""SeqId"") DO UPDATE SET
    ""Name"" = EXCLUDED.""Name"",
    ""Description"" = EXCLUDED.""Description"";
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
