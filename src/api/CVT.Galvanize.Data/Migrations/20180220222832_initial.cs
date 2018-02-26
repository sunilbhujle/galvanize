using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CVT.Galvanize.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientProvider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CvtSites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CvtSites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MatchId = table.Column<int>(nullable: false),
                    NoteText = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    AddressLine1 = table.Column<string>(maxLength: 150, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 150, nullable: true),
                    BackgroundCheck = table.Column<bool>(nullable: true),
                    BusinessPhone = table.Column<string>(maxLength: 150, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 150, nullable: true),
                    City = table.Column<string>(maxLength: 150, nullable: true),
                    CsInterest = table.Column<bool>(nullable: true),
                    CsOrientationdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateInterviewed = table.Column<DateTime>(type: "datetime", nullable: true),
                    Email1 = table.Column<string>(maxLength: 150, nullable: true),
                    Email2 = table.Column<string>(maxLength: 150, nullable: true),
                    FirstName = table.Column<string>(maxLength: 150, nullable: true),
                    Hippa = table.Column<bool>(nullable: true),
                    HomePhone = table.Column<string>(maxLength: 150, nullable: true),
                    ImportantNames = table.Column<string>(type: "text", nullable: true),
                    IsVolunteerCoordinator = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: true),
                    MandatedReporter = table.Column<bool>(nullable: true),
                    PostOrientationFollowupDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReferencesResponded = table.Column<int>(nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    Zip = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolunteringCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteringCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    VolunteerCoordinatorId = table.Column<int>(nullable: false),
                    VolunteerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Volunteers",
                        column: x => x.VolunteerCoordinatorId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Interactions",
                        column: x => x.VolunteerId,
                        principalTable: "Interactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Volunteers1",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerCvtSites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CvtSiteId = table.Column<int>(nullable: false),
                    VolunteerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerCvtSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteerCvtSites_CvtSites",
                        column: x => x.CvtSiteId,
                        principalTable: "CvtSites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VolunteerCvtSites_Volunteers",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(nullable: false),
                    VolunteerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteerLanguages_Languages",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VolunteerLanguages_Volunteers",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    NoteText = table.Column<string>(type: "text", nullable: true),
                    VolunteerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteerNotes_Volunteers",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VolunteerId = table.Column<int>(nullable: false),
                    VolunteeringCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteerInterests_Volunteers",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VolunteerInterests_VolunteringCategories",
                        column: x => x.VolunteeringCategoryId,
                        principalTable: "VolunteringCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchesClientProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientProviderId = table.Column<int>(nullable: false),
                    MatchesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesClientProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchesClientProviders_ClientProvider",
                        column: x => x.ClientProviderId,
                        principalTable: "ClientProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchesClientProviders_Matches",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchesVolunteerRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchesId = table.Column<int>(nullable: false),
                    VolunteerRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesVolunteerRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchesVolunteerRoles_Matches",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchesVolunteerRoles_VolunteerRoles",
                        column: x => x.VolunteerRoleId,
                        principalTable: "VolunteerRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_VolunteerCoordinatorId",
                table: "Matches",
                column: "VolunteerCoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_VolunteerId",
                table: "Matches",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesClientProviders_ClientProviderId",
                table: "MatchesClientProviders",
                column: "ClientProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesClientProviders_MatchesId",
                table: "MatchesClientProviders",
                column: "MatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesVolunteerRoles_MatchesId",
                table: "MatchesVolunteerRoles",
                column: "MatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesVolunteerRoles_VolunteerRoleId",
                table: "MatchesVolunteerRoles",
                column: "VolunteerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerCvtSites_CvtSiteId",
                table: "VolunteerCvtSites",
                column: "CvtSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerCvtSites_VolunteerId",
                table: "VolunteerCvtSites",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerInterests_VolunteerId",
                table: "VolunteerInterests",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerInterests_VolunteeringCategoryId",
                table: "VolunteerInterests",
                column: "VolunteeringCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerLanguages_LanguageId",
                table: "VolunteerLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerLanguages_VolunteerId",
                table: "VolunteerLanguages",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerNotes_VolunteerId",
                table: "VolunteerNotes",
                column: "VolunteerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchesClientProviders");

            migrationBuilder.DropTable(
                name: "MatchesVolunteerRoles");

            migrationBuilder.DropTable(
                name: "VolunteerCvtSites");

            migrationBuilder.DropTable(
                name: "VolunteerInterests");

            migrationBuilder.DropTable(
                name: "VolunteerLanguages");

            migrationBuilder.DropTable(
                name: "VolunteerNotes");

            migrationBuilder.DropTable(
                name: "ClientProvider");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "VolunteerRoles");

            migrationBuilder.DropTable(
                name: "CvtSites");

            migrationBuilder.DropTable(
                name: "VolunteringCategories");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Interactions");
        }
    }
}
