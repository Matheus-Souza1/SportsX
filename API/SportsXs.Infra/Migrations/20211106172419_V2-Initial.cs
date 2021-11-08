using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsXs.Infra.Migrations
{
    public partial class V2Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Client_ClientId",
                table: "Phones");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Client",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "Client",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Client_ClientId",
                table: "Phones",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Client_ClientId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Classification",
                table: "Client");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Client_ClientId",
                table: "Phones",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
