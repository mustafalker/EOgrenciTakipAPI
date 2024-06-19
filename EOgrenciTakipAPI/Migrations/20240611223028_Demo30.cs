using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOgrenciTakipAPI.Migrations
{
    /// <inheritdoc />
    public partial class Demo30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alanlar",
                columns: table => new
                {
                    AlanID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlanAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alanlar", x => x.AlanID);
                });

            migrationBuilder.CreateTable(
                name: "KonuBilgileri",
                columns: table => new
                {
                    KonuBilgisiID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KonuIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonuBilgileri", x => x.KonuBilgisiID);
                });

            migrationBuilder.CreateTable(
                name: "MufredatDersler",
                columns: table => new
                {
                    MufredatDersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DersSinavTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DersIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MufredatDersler", x => x.MufredatDersId);
                });

            migrationBuilder.CreateTable(
                name: "MufredatKonular",
                columns: table => new
                {
                    MufredatKonuId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DersSinavTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DersIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonuIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MufredatKonular", x => x.MufredatKonuId);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    OgrenciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlanID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.OgrenciID);
                    table.ForeignKey(
                        name: "FK_Ogrenciler_Alanlar_AlanID",
                        column: x => x.AlanID,
                        principalTable: "Alanlar",
                        principalColumn: "AlanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DersProgramlari",
                columns: table => new
                {
                    DersProgramiID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MinHedef = table.Column<int>(type: "int", nullable: false),
                    MaxHedef = table.Column<int>(type: "int", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GunlukCalismaSaati = table.Column<int>(type: "int", nullable: false),
                    HaftadaCalisilacakGunSayisi = table.Column<int>(type: "int", nullable: false),
                    AlanID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OgrenciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersProgramlari", x => x.DersProgramiID);
                    table.ForeignKey(
                        name: "FK_DersProgramlari_Alanlar_AlanID",
                        column: x => x.AlanID,
                        principalTable: "Alanlar",
                        principalColumn: "AlanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersProgramlari_Ogrenciler_OgrenciID",
                        column: x => x.OgrenciID,
                        principalTable: "Ogrenciler",
                        principalColumn: "OgrenciID");
                });

            migrationBuilder.CreateTable(
                name: "DersBilgileri",
                columns: table => new
                {
                    DersProgramiID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KonuBilgisiID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HaftadaDerseAyrilanSure = table.Column<int>(type: "int", nullable: false),
                    Ay = table.Column<int>(type: "int", nullable: false),
                    Hafta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersBilgileri", x => new { x.DersProgramiID, x.KonuBilgisiID });
                    table.ForeignKey(
                        name: "FK_DersBilgileri_DersProgramlari_DersProgramiID",
                        column: x => x.DersProgramiID,
                        principalTable: "DersProgramlari",
                        principalColumn: "DersProgramiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersBilgileri_KonuBilgileri_KonuBilgisiID",
                        column: x => x.KonuBilgisiID,
                        principalTable: "KonuBilgileri",
                        principalColumn: "KonuBilgisiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DersBilgileri_KonuBilgisiID",
                table: "DersBilgileri",
                column: "KonuBilgisiID");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlari_AlanID",
                table: "DersProgramlari",
                column: "AlanID");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlari_OgrenciID",
                table: "DersProgramlari",
                column: "OgrenciID");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_AlanID",
                table: "Ogrenciler",
                column: "AlanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersBilgileri");

            migrationBuilder.DropTable(
                name: "MufredatDersler");

            migrationBuilder.DropTable(
                name: "MufredatKonular");

            migrationBuilder.DropTable(
                name: "DersProgramlari");

            migrationBuilder.DropTable(
                name: "KonuBilgileri");

            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Alanlar");
        }
    }
}
