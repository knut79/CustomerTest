using Gyldendal.Customer.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gyldendal.Customer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FillTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (int i in System.Enum.GetValues(typeof(CustomerTypeEnum)))
            {
                migrationBuilder.InsertData(table: "CustomerType",
                    columns: new[] { "customertypeid", "name" },
                    values: new object[] { i, $"{System.Enum.GetName(typeof(CustomerTypeEnum), i)}" });

            }
            for (int i = 0; i < 100; i++)
            {
                migrationBuilder.InsertData(table: "customers",
                    columns: new[] { "ssn", "firstname", "lastname", "email", "customertypeid" },
                    values: new object[] { i.ToString(), "test", "test", "test@test", (i % 3) + 1 });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
