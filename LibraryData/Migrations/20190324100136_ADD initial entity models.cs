using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryData.Migrations
{
    public partial class ADDinitialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryBranchID",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserNLibraryCardameID",
                table: "users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "libraryBranches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    OpenDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraryBranches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "libraryCards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fees = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraryCards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "branchHours",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpenTime = table.Column<int>(nullable: false),
                    CloseTime = table.Column<int>(nullable: false),
                    DayOfWork = table.Column<int>(nullable: false),
                    BranchID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branchHours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_branchHours_libraryBranches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "libraryBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "libraryAssets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: true),
                    LocationID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Index = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraryAssets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_libraryAssets_libraryBranches_LocationID",
                        column: x => x.LocationID,
                        principalTable: "libraryBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_libraryAssets_statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chechouts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Since = table.Column<DateTime>(nullable: false),
                    Until = table.Column<DateTime>(nullable: false),
                    LibraryAssetID = table.Column<int>(nullable: true),
                    LibraryCardID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chechouts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_chechouts_libraryAssets_LibraryAssetID",
                        column: x => x.LibraryAssetID,
                        principalTable: "libraryAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chechouts_libraryCards_LibraryCardID",
                        column: x => x.LibraryCardID,
                        principalTable: "libraryCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "checkoutHistries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Checkout = table.Column<DateTime>(nullable: false),
                    Checkin = table.Column<DateTime>(nullable: true),
                    LibraryAssetID = table.Column<int>(nullable: true),
                    LibraryCardID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkoutHistries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_checkoutHistries_libraryAssets_LibraryAssetID",
                        column: x => x.LibraryAssetID,
                        principalTable: "libraryAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_checkoutHistries_libraryCards_LibraryCardID",
                        column: x => x.LibraryCardID,
                        principalTable: "libraryCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "holds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoldPlace = table.Column<DateTime>(nullable: false),
                    LibraryAssetID = table.Column<int>(nullable: true),
                    LibraryCardID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_holds_libraryAssets_LibraryAssetID",
                        column: x => x.LibraryAssetID,
                        principalTable: "libraryAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_holds_libraryCards_LibraryCardID",
                        column: x => x.LibraryCardID,
                        principalTable: "libraryCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_LibraryBranchID",
                table: "users",
                column: "LibraryBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserNLibraryCardameID",
                table: "users",
                column: "UserNLibraryCardameID");

            migrationBuilder.CreateIndex(
                name: "IX_branchHours_BranchID",
                table: "branchHours",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_chechouts_LibraryAssetID",
                table: "chechouts",
                column: "LibraryAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_chechouts_LibraryCardID",
                table: "chechouts",
                column: "LibraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_checkoutHistries_LibraryAssetID",
                table: "checkoutHistries",
                column: "LibraryAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_checkoutHistries_LibraryCardID",
                table: "checkoutHistries",
                column: "LibraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_holds_LibraryAssetID",
                table: "holds",
                column: "LibraryAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_holds_LibraryCardID",
                table: "holds",
                column: "LibraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_libraryAssets_LocationID",
                table: "libraryAssets",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_libraryAssets_StatusID",
                table: "libraryAssets",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_users_libraryBranches_LibraryBranchID",
                table: "users",
                column: "LibraryBranchID",
                principalTable: "libraryBranches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_libraryCards_UserNLibraryCardameID",
                table: "users",
                column: "UserNLibraryCardameID",
                principalTable: "libraryCards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_libraryBranches_LibraryBranchID",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_libraryCards_UserNLibraryCardameID",
                table: "users");

            migrationBuilder.DropTable(
                name: "branchHours");

            migrationBuilder.DropTable(
                name: "chechouts");

            migrationBuilder.DropTable(
                name: "checkoutHistries");

            migrationBuilder.DropTable(
                name: "holds");

            migrationBuilder.DropTable(
                name: "libraryAssets");

            migrationBuilder.DropTable(
                name: "libraryCards");

            migrationBuilder.DropTable(
                name: "libraryBranches");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropIndex(
                name: "IX_users_LibraryBranchID",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UserNLibraryCardameID",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LibraryBranchID",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserNLibraryCardameID",
                table: "users");
        }
    }
}
