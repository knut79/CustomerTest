using Gyldendal.Customer.Core.Enums;
using Gyldendal.Customer.Data.Enum;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gyldendal.Customer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FillDataInCustomerType : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
