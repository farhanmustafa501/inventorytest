using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceTest.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClosedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebtorReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebtorAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebtorRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
