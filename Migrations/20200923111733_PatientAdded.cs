using Microsoft.EntityFrameworkCore.Migrations;

namespace SahayogNepal.Migrations
{
    public partial class PatientAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HasDischargeReport",
                table: "Donors",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Age = table.Column<float>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<string>(nullable: true),
                    Hospital = table.Column<string>(nullable: true),
                    HasCaseSheet = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.AlterColumn<float>(
                name: "HasDischargeReport",
                table: "Donors",
                type: "real",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
