using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantTableBookingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class changesInDinningTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiningTable_RestaurantBranch_BranchId",
                table: "DiningTable");

            migrationBuilder.DropIndex(
                name: "IX_DiningTable_BranchId",
                table: "DiningTable");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "DiningTable");

            migrationBuilder.RenameColumn(
                name: "SeatsName",
                table: "DiningTable",
                newName: "TableName");

            migrationBuilder.CreateIndex(
                name: "IX_DiningTable_RestaurantBranchId",
                table: "DiningTable",
                column: "RestaurantBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiningTable_RestaurantBranch_RestaurantBranchId",
                table: "DiningTable",
                column: "RestaurantBranchId",
                principalTable: "RestaurantBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiningTable_RestaurantBranch_RestaurantBranchId",
                table: "DiningTable");

            migrationBuilder.DropIndex(
                name: "IX_DiningTable_RestaurantBranchId",
                table: "DiningTable");

            migrationBuilder.RenameColumn(
                name: "TableName",
                table: "DiningTable",
                newName: "SeatsName");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "DiningTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DiningTable_BranchId",
                table: "DiningTable",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiningTable_RestaurantBranch_BranchId",
                table: "DiningTable",
                column: "BranchId",
                principalTable: "RestaurantBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
