using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "PlaneId",
                table: "Flights");

            migrationBuilder.RenameTable(
                name: "Planes",
                newName: "MyPlanes");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "MyPlanes",
                newName: "PlaneCapacity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneFk",
                table: "Flights",
                column: "PlaneFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFk",
                table: "Flights",
                column: "PlaneFk",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFk",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PlaneFk",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "MyPlanes",
                newName: "Planes");

            migrationBuilder.RenameColumn(
                name: "PlaneCapacity",
                table: "Planes",
                newName: "Capacity");

            migrationBuilder.AddColumn<int>(
                name: "PlaneId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                table: "Planes",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
