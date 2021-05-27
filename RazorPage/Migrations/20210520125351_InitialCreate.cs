using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResidenceCountry = table.Column<string>(type: "TEXT", nullable: true),
                    WorkCountry = table.Column<string>(type: "TEXT", nullable: true),
                    PriceType = table.Column<string>(type: "TEXT", nullable: true),
                    PriceUnit = table.Column<string>(type: "TEXT", nullable: true),
                    NetSalary = table.Column<int>(type: "INTEGER", nullable: false),
                    BrutSalary = table.Column<int>(type: "INTEGER", nullable: false),
                    MonthDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    DayByMonthDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    Civility = table.Column<string>(type: "TEXT", nullable: true),
                    Lastname = table.Column<string>(type: "TEXT", nullable: true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    ConfidentialityPoliticAccepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    MarketingOfferAccepted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
