using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Migrations
{
    public partial class PhysicalAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhysicalAddress_CityOrTown",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhysicalAddress_CountryName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhysicalAddress_LineOne",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhysicalAddress_LineTwo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhysicalAddress_PostalOrZipCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhysicalAddress_StateOrProvince",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "PhysicalAddresses",
                columns: table => new
                {
                    LineOne = table.Column<string>(nullable: true),
                    LineTwo = table.Column<string>(nullable: true),
                    PostalOrZipCode = table.Column<string>(nullable: true),
                    StateOrProvince = table.Column<string>(nullable: true),
                    CityOrTown = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAddresses", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_PhysicalAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhysicalAddresses");

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddress_CityOrTown",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddress_CountryName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddress_LineOne",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddress_LineTwo",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddress_PostalOrZipCode",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddress_StateOrProvince",
                table: "Customers",
                nullable: true);
        }
    }
}
