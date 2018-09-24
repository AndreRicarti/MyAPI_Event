using Microsoft.EntityFrameworkCore.Migrations;

namespace My.API_Event.Migrations
{
    public partial class Company_Cnpj_Varchar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Companies",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cnpj",
                table: "Companies",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }
    }
}
