using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PaidBy_Changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_PaidByMemberId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PaidByMemberId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PaidByMemberId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "PaidBy",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidBy",
                table: "Expenses");

            migrationBuilder.AddColumn<Guid>(
                name: "PaidByMemberId",
                table: "Expenses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaidByMemberId",
                table: "Expenses",
                column: "PaidByMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_PaidByMemberId",
                table: "Expenses",
                column: "PaidByMemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
