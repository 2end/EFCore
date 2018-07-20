using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Migrations
{
    public partial class Customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WorkAddress_LineOne = table.Column<string>(nullable: true),
                    WorkAddress_LineTwo = table.Column<string>(nullable: true),
                    WorkAddress_PostalOrZipCode = table.Column<string>(nullable: true),
                    WorkAddress_StateOrProvince = table.Column<string>(nullable: true),
                    WorkAddress_CityOrTown = table.Column<string>(nullable: true),
                    WorkAddress_CountryName = table.Column<string>(nullable: true),
                    PhysicalAddress_LineOne = table.Column<string>(nullable: true),
                    PhysicalAddress_LineTwo = table.Column<string>(nullable: true),
                    PhysicalAddress_PostalOrZipCode = table.Column<string>(nullable: true),
                    PhysicalAddress_StateOrProvince = table.Column<string>(nullable: true),
                    PhysicalAddress_CityOrTown = table.Column<string>(nullable: true),
                    PhysicalAddress_CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
