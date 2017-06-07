using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resume.Migrations
{
    public partial class AccomplishmentFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accomplishment_JobID",
                table: "Accomplishment",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accomplishment_Job_JobID",
                table: "Accomplishment",
                column: "JobID",
                principalTable: "Job",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accomplishment_Job_JobID",
                table: "Accomplishment");

            migrationBuilder.DropIndex(
                name: "IX_Accomplishment_JobID",
                table: "Accomplishment");
        }
    }
}
