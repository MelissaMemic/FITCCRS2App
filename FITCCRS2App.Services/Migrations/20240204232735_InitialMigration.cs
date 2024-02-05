using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITCCRS2App.Services.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Napomena",
                columns: table => new
                {
                    NapomenaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poruka = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsernameTakmicar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Napomena", x => x.NapomenaId);
                });

            migrationBuilder.CreateTable(
                name: "Predavac",
                columns: table => new
                {
                    PredavacId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ustanova = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Zvanje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predavac", x => x.PredavacId);
                });

            migrationBuilder.CreateTable(
                name: "SKategorije",
                columns: table => new
                {
                    SKategorijeID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Iznos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKategorije", x => x.SKategorijeID);
                });

            migrationBuilder.CreateTable(
                name: "Takmicenje",
                columns: table => new
                {
                    TakmicenjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pocetak = table.Column<DateTime>(type: "datetime", nullable: true),
                    Kraj = table.Column<DateTime>(type: "datetime", nullable: true),
                    Godina = table.Column<int>(type: "int", nullable: true),
                    BrojDana = table.Column<int>(type: "int", nullable: true),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takmicenje", x => x.TakmicenjeID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendums",
                columns: table => new
                {
                    AgendaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dan = table.Column<int>(type: "int", nullable: true),
                    TakmicenjeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendums", x => x.AgendaID);
                    table.ForeignKey(
                        name: "FK_Agenda_Takmicenje",
                        column: x => x.TakmicenjeID,
                        principalTable: "Takmicenje",
                        principalColumn: "TakmicenjeID");
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TakmicenjeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaID);
                    table.ForeignKey(
                        name: "FK_Kategorija_Takmicenje",
                        column: x => x.TakmicenjeID,
                        principalTable: "Takmicenje",
                        principalColumn: "TakmicenjeID");
                });

            migrationBuilder.CreateTable(
                name: "Tim",
                columns: table => new
                {
                    TimID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojClanova = table.Column<int>(type: "int", nullable: false),
                    TakmicenjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tim", x => x.TimID);
                    table.ForeignKey(
                        name: "FK__Tim__TakmicenjeI__6166761E",
                        column: x => x.TakmicenjeID,
                        principalTable: "Takmicenje",
                        principalColumn: "TakmicenjeID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CitizenshipId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_User_Countries_CitizenshipId",
                        column: x => x.CitizenshipId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Dogadjaj",
                columns: table => new
                {
                    DogadjajID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Trajanje = table.Column<int>(type: "int", nullable: true),
                    Pocetak = table.Column<DateTime>(type: "datetime", nullable: true),
                    Kraj = table.Column<DateTime>(type: "datetime", nullable: true),
                    Napomena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgendaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogadjaj", x => x.DogadjajID);
                    table.ForeignKey(
                        name: "FK_Dogadjaj_Agenda",
                        column: x => x.AgendaID,
                        principalTable: "Agendums",
                        principalColumn: "AgendaID");
                });

            migrationBuilder.CreateTable(
                name: "Komisija",
                columns: table => new
                {
                    komisijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisija", x => x.komisijaId);
                    table.ForeignKey(
                        name: "FK_Komisija_Kategorija",
                        column: x => x.kategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID");
                });

            migrationBuilder.CreateTable(
                name: "Kriterij",
                columns: table => new
                {
                    KriterijID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Vrijednost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KategorijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kriterij", x => x.KriterijID);
                    table.ForeignKey(
                        name: "FK_Kriterij_Kategorija",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID");
                });

            migrationBuilder.CreateTable(
                name: "Sponzor",
                columns: table => new
                {
                    SponzorID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Godina = table.Column<int>(type: "int", nullable: true),
                    SKategorijeID = table.Column<int>(type: "int", nullable: false),
                    KategorijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponzor", x => x.SponzorID);
                    table.ForeignKey(
                        name: "FK__Sponzor__Kategor__756D6ECB",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID");
                    table.ForeignKey(
                        name: "FK__Sponzor__SKatego__76619304",
                        column: x => x.SKategorijeID,
                        principalTable: "SKategorije",
                        principalColumn: "SKategorijeID");
                });

            migrationBuilder.CreateTable(
                name: "Projekat",
                columns: table => new
                {
                    ProjekatID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KategorijaID = table.Column<int>(type: "int", nullable: false),
                    TimID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekat", x => x.ProjekatID);
                    table.ForeignKey(
                        name: "FK__Projekat__Katego__6442E2C9",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID");
                    table.ForeignKey(
                        name: "FK__Projekat__TimID__65370702",
                        column: x => x.TimID,
                        principalTable: "Tim",
                        principalColumn: "TimID");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PredavacDogadjaj",
                columns: table => new
                {
                    DogadjajId = table.Column<int>(type: "int", nullable: false),
                    PredavacId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredavacDogadjaj", x => new { x.DogadjajId, x.PredavacId });
                    table.ForeignKey(
                        name: "FK_PredavacDogadjaj_Dogadjaj_DogadjajId",
                        column: x => x.DogadjajId,
                        principalTable: "Dogadjaj",
                        principalColumn: "DogadjajID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredavacDogadjaj_Predavac_PredavacId",
                        column: x => x.PredavacId,
                        principalTable: "Predavac",
                        principalColumn: "PredavacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezultat",
                columns: table => new
                {
                    RezultatID = table.Column<int>(type: "int", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bod = table.Column<int>(type: "int", nullable: false),
                    ProjekatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezultat", x => x.RezultatID);
                    table.ForeignKey(
                        name: "FK__Rezultat__Projek__681373AD",
                        column: x => x.ProjekatID,
                        principalTable: "Projekat",
                        principalColumn: "ProjekatID");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Bosna i Hercegovina" },
                    { 2, "Crna Gora" },
                    { 3, "Njemacka" }
                });

            migrationBuilder.InsertData(
                table: "Napomena",
                columns: new[] { "NapomenaId", "Poruka", "UserName", "UsernameTakmicar" },
                values: new object[,]
                {
                    { 1, "poruka 1", "sponzor", "bablamija" },
                    { 2, "poruka 2", "sponzor", "bablamija" },
                    { 3, "poruka 3", "sponzor", "bablamija" }
                });

            migrationBuilder.InsertData(
                table: "Predavac",
                columns: new[] { "PredavacId", "Email", "Ime", "Prezime", "Ustanova", "Zvanje" },
                values: new object[,]
                {
                    { 1, "neko.ne@nesto.ba", "Neko", "Neko", "Firma", "Software inzenjer" },
                    { 2, "neko.dr@nesto.ba", "Neko", "Drugi", "Firma nova", "Software inzenjer" }
                });

            migrationBuilder.InsertData(
                table: "SKategorije",
                columns: new[] { "SKategorijeID", "Iznos", "Naziv" },
                values: new object[,]
                {
                    { 1, 2000, "Zlatni" },
                    { 2, 1500, "Srebreni" },
                    { 3, 1000, "Bronzani" }
                });

            migrationBuilder.InsertData(
                table: "Takmicenje",
                columns: new[] { "TakmicenjeID", "BrojDana", "Godina", "Kraj", "Naziv", "Pocetak", "Slika", "Slogan" },
                values: new object[] { 1, 2, 2022, new DateTime(2022, 5, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "FIT Coding Challenge 2022", new DateTime(2022, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, " " });

            migrationBuilder.InsertData(
                table: "Agendums",
                columns: new[] { "AgendaID", "Dan", "TakmicenjeID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name", "ZipCode" },
                values: new object[,]
                {
                    { 1, 1, "Mostar", "" },
                    { 2, 1, "Sarajevo", "" },
                    { 3, 1, "Tuzla", "" },
                    { 4, 1, "Capljina", "" },
                    { 5, 1, "Neum", "" }
                });

            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "KategorijaID", "Naziv", "Opis", "TakmicenjeID" },
                values: new object[,]
                {
                    { 1, "Programiraje", "Takmicenje u oblasti poznavanja programiranja", 1 },
                    { 2, "Inovacije", "Kreiranje najinovativnijeg rjesenja", 1 },
                    { 3, "Programiraje igara", "Takmicenje u oblasti poznavanja programiranja igara", 1 }
                });

            migrationBuilder.InsertData(
                table: "Sponzor",
                columns: new[] { "SponzorID", "Godina", "KategorijaID", "Naziv", "SKategorijeID" },
                values: new object[] { 2, 2022, null, "Sponzor", 2 });

            migrationBuilder.InsertData(
                table: "Tim",
                columns: new[] { "TimID", "BrojClanova", "Naziv", "TakmicenjeID" },
                values: new object[] { 1, 1, "Tim", 1 });

            migrationBuilder.InsertData(
                table: "Dogadjaj",
                columns: new[] { "DogadjajID", "AgendaID", "Kraj", "Lokacija", "Napomena", "Naziv", "Pocetak", "Trajanje" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 5, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 1", null, "Otvaranje", new DateTime(2022, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 30 },
                    { 2, 1, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 1", null, "Tribine", new DateTime(2022, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 3, 1, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 3", null, "Inovacije", new DateTime(2022, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 4, 1, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 2", null, "Programiranja", new DateTime(2022, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 5, 1, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "AKS", null, "Programiranja igara", new DateTime(2022, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 6, 2, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 1", null, "Proglasenje pobjednjika", new DateTime(2022, 5, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 7, 2, new DateTime(2022, 5, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 1", null, "Zatvaranje", new DateTime(2022, 5, 2, 12, 30, 0, 0, DateTimeKind.Unspecified), 30 }
                });

            migrationBuilder.InsertData(
                table: "Kriterij",
                columns: new[] { "KriterijID", "KategorijaID", "Naziv", "Vrijednost" },
                values: new object[,]
                {
                    { 1, 2, "Inovativnost", "50" },
                    { 2, 2, "Implementacija", "50" }
                });

            migrationBuilder.InsertData(
                table: "Projekat",
                columns: new[] { "ProjekatID", "KategorijaID", "Naziv", "Opis", "TimID" },
                values: new object[] { 1, 2, "Neki projekat", "Inovativan projekat. Code dostupan na githubu.", 1 });

            migrationBuilder.InsertData(
                table: "Sponzor",
                columns: new[] { "SponzorID", "Godina", "KategorijaID", "Naziv", "SKategorijeID" },
                values: new object[] { 1, 2022, 2, "Sponzor", 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "BirthDate", "CitizenshipId", "CityId", "CreateDate", "Email", "FirstName", "Gender", "Image", "LastName", "Password", "Phone", "Username", "WebSite" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4540), 1, 1, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4500), "mellimostar@gmail.com", "Melissa", 1, "", "Memic", "19a2854144b63a8f7617a6f225019b12", "+333 22 3 332", "meli", "http://google.com" },
                    { 2, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4560), 1, 2, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4560), "lamija.babovic@edu.fit.ba", "lamija", 1, "", "Babovic", "19a2854144b63a8f7617a6f225019b12", "+333 22 3 332", "lamija", "http://google.com" },
                    { 3, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4580), 1, 2, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4580), "ziri@gmail.com", "Ziri", 1, "", "Ziri", "19a2854144b63a8f7617a6f225019b12", "+333 22 3 332", "ziri", "http://google.com" },
                    { 4, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4600), 1, 3, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4590), "bablamija@gmail.com", "lamija", 1, "", "Bab", "19a2854144b63a8f7617a6f225019b12", "+333 22 3 332", "bablamija", "http://google.com" },
                    { 5, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4610), 1, 1, new DateTime(2024, 2, 5, 0, 27, 34, 883, DateTimeKind.Local).AddTicks(4610), "sponzor@gmail.com", "Sponzor", 0, "", "Sponzor", "19a2854144b63a8f7617a6f225019b12", "+333 22 3 332", "sponzor", "http://google.com" }
                });

            migrationBuilder.InsertData(
                table: "PredavacDogadjaj",
                columns: new[] { "DogadjajId", "PredavacId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Rezultat",
                columns: new[] { "RezultatID", "Bod", "Napomena", "ProjekatID" },
                values: new object[] { 1, 90, "Neka napomena", 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "Role", "UserId" },
                values: new object[,]
                {
                    { 1, "Admin", 1 },
                    { 2, "Admin", 2 },
                    { 3, "Ziri", 3 },
                    { 4, "Takmicar", 4 },
                    { 5, "Sponzor", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_TakmicenjeID",
                table: "Agendums",
                column: "TakmicenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogadjaj_AgendaID",
                table: "Dogadjaj",
                column: "AgendaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorija_TakmicenjeID",
                table: "Kategorija",
                column: "TakmicenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Komisija_kategorijaId",
                table: "Komisija",
                column: "kategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kriterij_KategorijaID",
                table: "Kriterij",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_PredavacDogadjaj_PredavacId",
                table: "PredavacDogadjaj",
                column: "PredavacId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekat_KategorijaID",
                table: "Projekat",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Projekat_TimID",
                table: "Projekat",
                column: "TimID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezultat_ProjekatID",
                table: "Rezultat",
                column: "ProjekatID");

            migrationBuilder.CreateIndex(
                name: "IX_Sponzor_KategorijaID",
                table: "Sponzor",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sponzor_SKategorijeID",
                table: "Sponzor",
                column: "SKategorijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tim_TakmicenjeID",
                table: "Tim",
                column: "TakmicenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CitizenshipId",
                table: "User",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CityId",
                table: "User",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komisija");

            migrationBuilder.DropTable(
                name: "Kriterij");

            migrationBuilder.DropTable(
                name: "Napomena");

            migrationBuilder.DropTable(
                name: "PredavacDogadjaj");

            migrationBuilder.DropTable(
                name: "Rezultat");

            migrationBuilder.DropTable(
                name: "Sponzor");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Dogadjaj");

            migrationBuilder.DropTable(
                name: "Predavac");

            migrationBuilder.DropTable(
                name: "Projekat");

            migrationBuilder.DropTable(
                name: "SKategorije");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Agendums");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Tim");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Takmicenje");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
