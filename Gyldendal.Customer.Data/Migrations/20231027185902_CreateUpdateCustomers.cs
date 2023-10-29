using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gyldendal.Customer.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateUpdateCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "customers",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "customers",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "customerType",
                table: "customers",
                newName: "customertype");

            migrationBuilder.AddColumn<string>(
                name: "testmigration",
                table: "customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testmigration",
                table: "customers");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "customers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "customers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "customertype",
                table: "customers",
                newName: "customerType");
        }
    }
}
