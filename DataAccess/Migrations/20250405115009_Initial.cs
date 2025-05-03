using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FootballTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "FootballPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_FootballTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "FootballTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_FootballTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "FootballTeams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteItems",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteItems", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_FavoriteItems_FootballTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "FootballTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteItems_FootballTeams_UserId1",
                        column: x => x.UserId1,
                        principalTable: "FootballTeams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FootballTeams",
                columns: new[] { "Id", "Country", "Logo", "Name" },
                values: new object[,]
                {
                    { 1, "Spain", "https://upload.wikimedia.org/wikipedia/en/4/47/FC_Barcelona_%28crest%29.svg", "FC Barcelona" },
                    { 2, "Spain", "https://upload.wikimedia.org/wikipedia/en/5/56/Real_Madrid_CF.svg", "Real Madrid" },
                    { 3, "England", "https://upload.wikimedia.org/wikipedia/en/7/7a/Manchester_United_FC_crest.svg", "Manchester United" },
                    { 4, "England", "https://upload.wikimedia.org/wikipedia/en/e/eb/Manchester_City_FC_badge.svg", "Manchester City" },
                    { 5, "England", "https://upload.wikimedia.org/wikipedia/en/0/0c/Liverpool_FC.svg", "Liverpool" },
                    { 6, "France", "https://upload.wikimedia.org/wikipedia/en/a/a7/Paris_Saint-Germain_F.C..svg", "Paris Saint-Germain" },
                    { 7, "Germany", "https://upload.wikimedia.org/wikipedia/en/c/c5/Bayern_Munich_logo_%282017%29.svg", "Bayern Munich" },
                    { 8, "Germany", "https://upload.wikimedia.org/wikipedia/en/6/67/Borussia_Dortmund_logo.svg", "Borussia Dortmund" },
                    { 9, "Italy", "https://upload.wikimedia.org/wikipedia/en/d/d2/Juventus_FC_2017_logo.svg", "Juventus" },
                    { 10, "Italy", "https://upload.wikimedia.org/wikipedia/en/0/05/Inter_Milan_2021_logo.svg", "Inter Milan" },
                    { 11, "Italy", "https://upload.wikimedia.org/wikipedia/commons/d/d0/Logo_of_AC_Milan.svg", "AC Milan" },
                    { 12, "England", "https://upload.wikimedia.org/wikipedia/en/5/53/Arsenal_FC.svg", "Arsenal" },
                    { 13, "England", "https://upload.wikimedia.org/wikipedia/en/c/cc/Chelsea_FC.svg", "Chelsea" },
                    { 14, "Spain", "https://upload.wikimedia.org/wikipedia/en/f/f4/Atletico_Madrid_2017_logo.svg", "Atletico Madrid" },
                    { 15, "Italy", "https://upload.wikimedia.org/wikipedia/en/2/28/SSC_Napoli.svg", "Napoli" },
                    { 16, "Italy", "https://upload.wikimedia.org/wikipedia/en/0/04/AS_Roma_logo_%282017%29.svg", "AS Roma" },
                    { 17, "England", "https://upload.wikimedia.org/wikipedia/en/b/b4/Tottenham_Hotspur.svg", "Tottenham Hotspur" },
                    { 18, "Spain", "https://upload.wikimedia.org/wikipedia/en/8/86/Sevilla_FC_logo.svg", "Sevilla" },
                    { 19, "Germany", "https://upload.wikimedia.org/wikipedia/en/a/a5/RB_Leipzig_2014_logo.svg", "RB Leipzig" },
                    { 20, "Netherlands", "https://upload.wikimedia.org/wikipedia/en/7/7f/Ajax_Amsterdam.svg", "Ajax" }
                });

            migrationBuilder.InsertData(
                table: "FootballPlayers",
                columns: new[] { "Id", "Birthdate", "FirstName", "Goals", "LastName", "Number", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(1987, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lionel", 750, "Messi", 10, 6 },
                    { 2, new DateTime(1985, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristiano", 800, "Ronaldo", 7, 9 },
                    { 3, new DateTime(1992, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neymar", 350, "Jr", 11, 6 },
                    { 4, new DateTime(1998, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kylian", 250, "Mbappe", 7, 6 },
                    { 5, new DateTime(1988, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", 500, "Lewandowski", 9, 7 },
                    { 6, new DateTime(1991, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", 150, "De Bruyne", 17, 4 },
                    { 7, new DateTime(2000, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erling", 200, "Haaland", 9, 8 },
                    { 8, new DateTime(1992, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohamed", 300, "Salah", 11, 5 },
                    { 9, new DateTime(1991, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgil", 50, "van Dijk", 4, 5 },
                    { 10, new DateTime(1986, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergio", 100, "Ramos", 4, 6 },
                    { 11, new DateTime(1987, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karim", 400, "Benzema", 9, 2 },
                    { 12, new DateTime(1985, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luka", 120, "Modric", 10, 2 },
                    { 13, new DateTime(1993, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry", 350, "Kane", 10, 17 },
                    { 14, new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Son", 200, "Heung-min", 7, 17 },
                    { 15, new DateTime(1994, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruno", 180, "Fernandes", 8, 3 },
                    { 16, new DateTime(1997, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcus", 150, "Rashford", 10, 3 },
                    { 17, new DateTime(1991, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antoine", 250, "Griezmann", 7, 14 },
                    { 18, new DateTime(1993, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paulo", 150, "Dybala", 21, 16 },
                    { 19, new DateTime(1993, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romelu", 250, "Lukaku", 9, 10 },
                    { 20, new DateTime(1995, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshua", 100, "Kimmich", 6, 7 },
                    { 21, new DateTime(2000, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alphonso", 50, "Davies", 19, 7 },
                    { 22, new DateTime(2000, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jadon", 90, "Sancho", 25, 3 },
                    { 23, new DateTime(1995, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack", 80, "Grealish", 10, 4 },
                    { 24, new DateTime(2000, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phil", 100, "Foden", 47, 4 },
                    { 25, new DateTime(2002, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedri", 50, "", 8, 1 },
                    { 26, new DateTime(2004, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gavi", 40, "", 30, 1 },
                    { 27, new DateTime(1999, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Declan", 60, "Rice", 41, 12 },
                    { 28, new DateTime(2003, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jude", 70, "Bellingham", 22, 2 },
                    { 29, new DateTime(2000, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vinicius", 90, "Jr", 20, 2 },
                    { 30, new DateTime(2002, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduardo", 50, "Camavinga", 12, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItems_TeamId",
                table: "FavoriteItems",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItems_UserId1",
                table: "FavoriteItems",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_TeamId",
                table: "FootballPlayers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteItems");

            migrationBuilder.DropTable(
                name: "FootballPlayers");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FootballTeams");
        }
    }
}
