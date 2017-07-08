using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YelpAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YelpAuthToken",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    access_token = table.Column<string>(nullable: true),
                    expire_date = table.Column<DateTime>(nullable: false),
                    token_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YelpAuthToken", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "YelpSearch",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    Term = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YelpSearch", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Center",
                columns: table => new
                {
                    CenterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.CenterID);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    CoordinatesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.CoordinatesID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address1 = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    address3 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CenterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                    table.ForeignKey(
                        name: "FK_Region_Center_CenterID",
                        column: x => x.CenterID,
                        principalTable: "Center",
                        principalColumn: "CenterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YelpSearchResult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegionID = table.Column<int>(nullable: true),
                    total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YelpSearchResult", x => x.ID);
                    table.ForeignKey(
                        name: "FK_YelpSearchResult_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoordinatesID = table.Column<int>(nullable: true),
                    LocationID = table.Column<int>(nullable: true),
                    YelpSearchResultID = table.Column<int>(nullable: true),
                    distance = table.Column<double>(nullable: false),
                    id = table.Column<string>(nullable: true),
                    image_url = table.Column<string>(nullable: true),
                    is_closed = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    rating = table.Column<int>(nullable: false),
                    review_count = table.Column<int>(nullable: false),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessID);
                    table.ForeignKey(
                        name: "FK_Business_Coordinates_CoordinatesID",
                        column: x => x.CoordinatesID,
                        principalTable: "Coordinates",
                        principalColumn: "CoordinatesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_YelpSearchResult_YelpSearchResultID",
                        column: x => x.YelpSearchResultID,
                        principalTable: "YelpSearchResult",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessID = table.Column<int>(nullable: true),
                    alias = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_Business_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Business",
                        principalColumn: "BusinessID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YelpSearchResult_RegionID",
                table: "YelpSearchResult",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CoordinatesID",
                table: "Business",
                column: "CoordinatesID");

            migrationBuilder.CreateIndex(
                name: "IX_Business_LocationID",
                table: "Business",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Business_YelpSearchResultID",
                table: "Business",
                column: "YelpSearchResultID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_BusinessID",
                table: "Category",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CenterID",
                table: "Region",
                column: "CenterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YelpAuthToken");

            migrationBuilder.DropTable(
                name: "YelpSearch");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "YelpSearchResult");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Center");
        }
    }
}
