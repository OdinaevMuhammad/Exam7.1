using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inditd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Regions_Regionid",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Locations_Locationid",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Jobs_JobId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Employees_EmployeeId",
                table: "JobHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Jobs_JobId",
                table: "JobHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CountryId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_JobId",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Locationid",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Regionid",
                table: "Countries");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "JobHistories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "JobHistories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_JobId",
                table: "JobHistories",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobId",
                table: "Employees",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Locationid",
                table: "Departments",
                column: "Locationid");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Regionid",
                table: "Countries",
                column: "Regionid");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Regions_Regionid",
                table: "Countries",
                column: "Regionid",
                principalTable: "Regions",
                principalColumn: "Regionid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Locations_Locationid",
                table: "Departments",
                column: "Locationid",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Jobs_JobId",
                table: "Employees",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "jobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Employees_EmployeeId",
                table: "JobHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Jobs_JobId",
                table: "JobHistories",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "jobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
