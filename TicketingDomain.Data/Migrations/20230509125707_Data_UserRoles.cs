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
            migrationBuilder.Sql(
                @"SET IDENTITY_INSERT TicketingDomain.UserRole ON; 
                    MERGE TicketingDomain.UserRole
                    USING (
                        SELECT * FROM (
                            VALUES
                            ('Admin', 'Admin', 1),
                            ('Event Manager', 'Event Manager', 2),
                            ('Customer', 'Customer', 3)
                        ) Roles(RoleName, Description, SeqId)
                    ) Roles(RoleName, Description, SeqId) ON TicketingDomain.UserRole.SeqId = Roles.SeqId
                    WHEN MATCHED
                        THEN UPDATE SET TicketingDomain.UserRole.RoleName = RoleName
                    WHEN NOT MATCHED
                        THEN INSERT (RoleName, Description, SeqId) VALUES (Role.RoleName, Roles.Description, Roles.SeqId)
                    OUTPUT $action, inserted.*, deleted.*;
                    SET IDENTITY_INSERT TicketingDomain.UserRole OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
