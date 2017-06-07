using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Resume.Migrations
{
    public partial class AccomplishmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accomplishment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccomplishmentID = table.Column<int>(nullable: true),
                    JobID = table.Column<int>(nullable: true),
                    accomplishment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accomplishment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accomplishment_Accomplishment_AccomplishmentID",
                        column: x => x.AccomplishmentID,
                        principalTable: "Accomplishment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accomplishment_AccomplishmentID",
                table: "Accomplishment",
                column: "AccomplishmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accomplishment");
        }
    }
}
