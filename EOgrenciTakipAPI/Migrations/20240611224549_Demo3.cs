using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOgrenciTakipAPI.Migrations
{
    /// <inheritdoc />
    public partial class Demo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrenciler_Alanlar_AlanID",
                table: "Ogrenciler");

            migrationBuilder.DropIndex(
                name: "IX_Ogrenciler_AlanID",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "AlanID",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "Field",
                table: "DersProgramlari");

            migrationBuilder.DropColumn(
                name: "MaxHedef",
                table: "DersProgramlari");

            migrationBuilder.DropColumn(
                name: "MinHedef",
                table: "DersProgramlari");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlanID",
                table: "Ogrenciler",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "DersProgramlari",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxHedef",
                table: "DersProgramlari",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinHedef",
                table: "DersProgramlari",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_AlanID",
                table: "Ogrenciler",
                column: "AlanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrenciler_Alanlar_AlanID",
                table: "Ogrenciler",
                column: "AlanID",
                principalTable: "Alanlar",
                principalColumn: "AlanID");
        }
    }
}
