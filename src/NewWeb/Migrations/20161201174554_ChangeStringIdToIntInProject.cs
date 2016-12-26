using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NewWeb.Migrations
{
    public partial class ChangeStringIdToIntInProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Projects",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "DoctorProjects",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "Projects",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "DoctorProjects",
                nullable: false);
        }
    }
}
