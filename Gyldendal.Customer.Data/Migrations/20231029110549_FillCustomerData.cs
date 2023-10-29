using Gyldendal.Customer.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gyldendal.Customer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FillCustomerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for(int i = 0 ; i < 1000; i++)
            {
                migrationBuilder.InsertData(table: "customers",
                    columns: new[] { "ssn", "firstname","lastname","email","customertypeid" },
                    values: new object[] { i, "test","test", "test@test",(i % 3) + 1 });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
