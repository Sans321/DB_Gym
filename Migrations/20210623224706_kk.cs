using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasseinProekta.Migrations
{
    public partial class kk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kartas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateNachala = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spravkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateNachala = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupZdorovie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dopusk = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spravkas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTreners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Programma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTreners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeVannas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Forma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeVannas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeZanRtis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Programma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeZanRtis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpravkaID = table.Column<int>(type: "int", nullable: false),
                    FamiliR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otchestvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeriaPasport = table.Column<int>(type: "int", nullable: false),
                    NomerPasporta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klients_Spravkas_SpravkaID",
                        column: x => x.SpravkaID,
                        principalTable: "Spravkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeGroupID = table.Column<int>(type: "int", nullable: false),
                    KartaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Kartas_KartaId",
                        column: x => x.KartaId,
                        principalTable: "Kartas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_TypeGroups_TypeGroupID",
                        column: x => x.TypeGroupID,
                        principalTable: "TypeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vannas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeVannaID = table.Column<int>(type: "int", nullable: false),
                    NomerVanna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shirina = table.Column<int>(type: "int", nullable: false),
                    Glubina = table.Column<int>(type: "int", nullable: false),
                    Dlina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vannas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vannas_TypeVannas_TypeVannaID",
                        column: x => x.TypeVannaID,
                        principalTable: "TypeVannas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KartaKlientas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KartaID = table.Column<int>(type: "int", nullable: false),
                    KlientID = table.Column<int>(type: "int", nullable: false),
                    DateNachala = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomerKartKlienta = table.Column<int>(type: "int", nullable: false),
                    SpravkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartaKlientas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KartaKlientas_Kartas_KartaID",
                        column: x => x.KartaID,
                        principalTable: "Kartas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KartaKlientas_Klients_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KartaKlientas_Spravkas_SpravkaId",
                        column: x => x.SpravkaId,
                        principalTable: "Spravkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kontakts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlientID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kontakts_Klients_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamiliR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otchestvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    TypeTrenerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treners_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treners_TypeTreners_TypeTrenerID",
                        column: x => x.TypeTrenerID,
                        principalTable: "TypeTreners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ychets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    KartaKlientaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ychets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ychets_KartaKlientas_KartaKlientaID",
                        column: x => x.KartaKlientaID,
                        principalTable: "KartaKlientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZanRtis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KartaKlientaID = table.Column<int>(type: "int", nullable: false),
                    TypeZanRtiID = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZanRtis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZanRtis_KartaKlientas_KartaKlientaID",
                        column: x => x.KartaKlientaID,
                        principalTable: "KartaKlientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZanRtis_TypeZanRtis_TypeZanRtiID",
                        column: x => x.TypeZanRtiID,
                        principalTable: "TypeZanRtis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Raspisanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KartaKlientaID = table.Column<int>(type: "int", nullable: false),
                    TrenerID = table.Column<int>(type: "int", nullable: false),
                    VannaID = table.Column<int>(type: "int", nullable: false),
                    DateNachala = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspisanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raspisanies_KartaKlientas_KartaKlientaID",
                        column: x => x.KartaKlientaID,
                        principalTable: "KartaKlientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Raspisanies_Treners_TrenerID",
                        column: x => x.TrenerID,
                        principalTable: "Treners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Raspisanies_Vannas_VannaID",
                        column: x => x.VannaID,
                        principalTable: "Vannas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_KartaId",
                table: "Groups",
                column: "KartaId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TypeGroupID",
                table: "Groups",
                column: "TypeGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_KartaKlientas_KartaID",
                table: "KartaKlientas",
                column: "KartaID");

            migrationBuilder.CreateIndex(
                name: "IX_KartaKlientas_KlientID",
                table: "KartaKlientas",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_KartaKlientas_SpravkaId",
                table: "KartaKlientas",
                column: "SpravkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Klients_SpravkaID",
                table: "Klients",
                column: "SpravkaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kontakts_KlientID",
                table: "Kontakts",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_Raspisanies_KartaKlientaID",
                table: "Raspisanies",
                column: "KartaKlientaID");

            migrationBuilder.CreateIndex(
                name: "IX_Raspisanies_TrenerID",
                table: "Raspisanies",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Raspisanies_VannaID",
                table: "Raspisanies",
                column: "VannaID");

            migrationBuilder.CreateIndex(
                name: "IX_Treners_GroupID",
                table: "Treners",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Treners_TypeTrenerID",
                table: "Treners",
                column: "TypeTrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Vannas_TypeVannaID",
                table: "Vannas",
                column: "TypeVannaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ychets_KartaKlientaID",
                table: "Ychets",
                column: "KartaKlientaID");

            migrationBuilder.CreateIndex(
                name: "IX_ZanRtis_KartaKlientaID",
                table: "ZanRtis",
                column: "KartaKlientaID");

            migrationBuilder.CreateIndex(
                name: "IX_ZanRtis_TypeZanRtiID",
                table: "ZanRtis",
                column: "TypeZanRtiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontakts");

            migrationBuilder.DropTable(
                name: "Raspisanies");

            migrationBuilder.DropTable(
                name: "Ychets");

            migrationBuilder.DropTable(
                name: "ZanRtis");

            migrationBuilder.DropTable(
                name: "Treners");

            migrationBuilder.DropTable(
                name: "Vannas");

            migrationBuilder.DropTable(
                name: "KartaKlientas");

            migrationBuilder.DropTable(
                name: "TypeZanRtis");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "TypeTreners");

            migrationBuilder.DropTable(
                name: "TypeVannas");

            migrationBuilder.DropTable(
                name: "Klients");

            migrationBuilder.DropTable(
                name: "Kartas");

            migrationBuilder.DropTable(
                name: "TypeGroups");

            migrationBuilder.DropTable(
                name: "Spravkas");
        }
    }
}
