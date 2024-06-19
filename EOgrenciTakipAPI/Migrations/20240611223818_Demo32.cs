using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOgrenciTakipAPI.Migrations
{
    /// <inheritdoc />
    public partial class Demo32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DersProgramlari_Alanlar_AlanID",
                table: "DersProgramlari");

            migrationBuilder.DropForeignKey(
                name: "FK_DersProgramlari_Ogrenciler_OgrenciID",
                table: "DersProgramlari");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogrenciler_Alanlar_AlanID",
                table: "Ogrenciler");

            migrationBuilder.DropIndex(
                name: "IX_DersProgramlari_AlanID",
                table: "DersProgramlari");

            migrationBuilder.DropIndex(
                name: "IX_DersProgramlari_OgrenciID",
                table: "DersProgramlari");

            migrationBuilder.DropColumn(
                name: "AlanID",
                table: "DersProgramlari");

            migrationBuilder.DropColumn(
                name: "OgrenciID",
                table: "DersProgramlari");

            migrationBuilder.AlterColumn<string>(
                name: "AlanID",
                table: "Ogrenciler",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Alan",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxHedef",
                table: "Ogrenciler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinHedef",
                table: "Ogrenciler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrenciler_Alanlar_AlanID",
                table: "Ogrenciler",
                column: "AlanID",
                principalTable: "Alanlar",
                principalColumn: "AlanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrenciler_Alanlar_AlanID",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "Alan",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "MaxHedef",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "MinHedef",
                table: "Ogrenciler");

            migrationBuilder.AlterColumn<string>(
                name: "AlanID",
                table: "Ogrenciler",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlanID",
                table: "DersProgramlari",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OgrenciID",
                table: "DersProgramlari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlari_AlanID",
                table: "DersProgramlari",
                column: "AlanID");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlari_OgrenciID",
                table: "DersProgramlari",
                column: "OgrenciID");

            migrationBuilder.AddForeignKey(
                name: "FK_DersProgramlari_Alanlar_AlanID",
                table: "DersProgramlari",
                column: "AlanID",
                principalTable: "Alanlar",
                principalColumn: "AlanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DersProgramlari_Ogrenciler_OgrenciID",
                table: "DersProgramlari",
                column: "OgrenciID",
                principalTable: "Ogrenciler",
                principalColumn: "OgrenciID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrenciler_Alanlar_AlanID",
                table: "Ogrenciler",
                column: "AlanID",
                principalTable: "Alanlar",
                principalColumn: "AlanID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
