using Gyldendal.Customer.Data.Enum;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gyldendal.Customer.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateUpdateCustomers3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "customertype",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "testmigration",
                table: "customers");

            migrationBuilder.AddColumn<int>(
                name: "customertypeid",
                table: "customers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    customertypeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.customertypeid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_customertypeid",
                table: "customers",
                column: "customertypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_CustomerType_customertypeid",
                table: "customers",
                column: "customertypeid",
                principalTable: "CustomerType",
                principalColumn: "customertypeid");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_CustomerType_customertypeid",
                table: "customers");

            migrationBuilder.DropTable(
                name: "CustomerType");

            migrationBuilder.DropIndex(
                name: "IX_customers_customertypeid",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "customertypeid",
                table: "customers");

            migrationBuilder.AddColumn<string>(
                name: "customertype",
                table: "customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "testmigration",
                table: "customers",
                type: "text",
                nullable: true);
        }
    }
}
