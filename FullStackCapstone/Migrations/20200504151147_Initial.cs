using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackCapstone.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ApplicationLink = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    AgeRange = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false),
                    ProgramTypeId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ApplicationDeadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunity_ProgramType_ProgramTypeId",
                        column: x => x.ProgramTypeId,
                        principalTable: "ProgramType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opportunity_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OppCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpportunityId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OppCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OppCart_Opportunity_OpportunityId",
                        column: x => x.OpportunityId,
                        principalTable: "Opportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OppCart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "1804c298-d5c8-4f1c-afb5-bb999c59de28", "admin@admin.com", true, "Admina", true, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMyQ3uwXhohCxZ8f0AzbRiTTESAEEtOTCV8Zb67poQhukfMI6/2cA+9xTHaFQCYBOQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "ProgramType",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Day Program" },
                    { 2, "Residential Program" },
                    { 3, "Travel Program" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Mathematics" },
                    { 2, "Coding" },
                    { 3, "Writing" },
                    { 4, "Sports" },
                    { 5, "Music" },
                    { 6, "Science" },
                    { 7, "STEM" },
                    { 8, "College Classes" },
                    { 9, "Math and Science" }
                });

            migrationBuilder.InsertData(
                table: "Opportunity",
                columns: new[] { "Id", "AgeRange", "ApplicationDeadline", "ApplicationLink", "Description", "EndDate", "IsActive", "ProgramTypeId", "StartDate", "SubjectId", "Title" },
                values: new object[,]
                {
                    { 7, "Girls 16 or 17 years old", new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.inspiringgirls.org/about-apply", "Inspiring young women through science, art, and wilderness exploration. Apply to join other young girls on unique, one-week long wilderness expeditions.", new DateTime(2020, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Inspiring Girls Expedition" },
                    { 1, "High School Girls", new DateTime(2020, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.adventuresci.org/twister", "Tennessee Women in Science, Technology, Engineering & Research (TWISTER) is a one day professional conference for high school girls, presented by women working in STEM (science, technology, engineering and research) professions.", new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "TWISTER Conference" },
                    { 2, "Current High School Juniors", new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "summerscience.org/the-ssp-experience/what-is-ssp/", "A 39-day residential enrichment program designed to challenge and inspire talented and motivated rising seniors through hands-on research.", new DateTime(2020, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Summer Science Program" },
                    { 4, "Rising 7th through 12th grade girls", new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "harpethhall.org/stem-summer-institute-registration", "Girls will participate in a research-based STEM curriculum and use the engineering design process to solve real-world problems.", new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Harpeth Hall STEM Summer Institute" },
                    { 3, null, new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "summer.uchicago.edu/programs/uchicago-summer-scholars", "Being a UChicago Summer Scholar is a great way to get an early look at college-level classes and get a feel for life on campus and in Chicago. You’ll also learn in-depth about the application process for highly selective universities with the guidance of UChicago admissions counselors.", new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "UChicago Summer Scholars" },
                    { 5, "Rising Junior or Senior Girls", new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sites.coecis.cornell.edu/curieacademy/", "Curie Academy is a one-week residential program for high school girls who excel in math and science. This summer come to Cornell University and explore the many possibilities awaiting you in engineering.", new DateTime(2020, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Curie Academy" },
                    { 6, "Rising Seniors", new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.vumc.org/dbmi/summer-research-internship-program-biomedical-informatics", "Provides students from diverse backgrounds with a high quality Biomedical Informatics research experience at Vanderbilt University.", new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Summer Research Internship Program" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OppCart_OpportunityId",
                table: "OppCart",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_OppCart_UserId",
                table: "OppCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_ProgramTypeId",
                table: "Opportunity",
                column: "ProgramTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_SubjectId",
                table: "Opportunity",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OppCart");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Opportunity");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProgramType");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
