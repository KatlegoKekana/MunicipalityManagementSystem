using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceRequestId",
                table: "ServiceRequests",
                newName: "ServiceRequestID");

            migrationBuilder.RenameColumn(
                name: "Satus",
                table: "ServiceRequests",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceRequestID",
                table: "ServiceRequests",
                newName: "ServiceRequestId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ServiceRequests",
                newName: "Satus");
        }
    }
}
