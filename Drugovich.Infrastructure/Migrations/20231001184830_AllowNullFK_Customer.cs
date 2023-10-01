using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drugovich.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullFK_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerGroups_Id",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "FK_CustomerGroup",
                table: "Customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FK_CustomerGroup",
                table: "Customers",
                column: "FK_CustomerGroup",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerGroups_FK_CustomerGroup",
                table: "Customers",
                column: "FK_CustomerGroup",
                principalTable: "CustomerGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerGroups_FK_CustomerGroup",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FK_CustomerGroup",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FK_CustomerGroup",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerGroups_Id",
                table: "Customers",
                column: "Id",
                principalTable: "CustomerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
