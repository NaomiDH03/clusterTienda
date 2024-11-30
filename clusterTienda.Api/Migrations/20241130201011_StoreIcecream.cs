using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clusterTienda.Api.Migrations
{
    /// <inheritdoc />
    public partial class StoreIcecream : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Icecreams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Icecreams_StoreId",
                table: "Icecreams",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecreams_Stores_StoreId",
                table: "Icecreams",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecreams_Stores_StoreId",
                table: "Icecreams");

            migrationBuilder.DropIndex(
                name: "IX_Icecreams_StoreId",
                table: "Icecreams");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Icecreams");
        }
    }
}
