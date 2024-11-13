using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseMember_Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseMembers_Expenses_ExpenseId",
                table: "ExpenseMembers");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseMembers_Expenses_ExpenseId",
                table: "ExpenseMembers",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseMembers_Expenses_ExpenseId",
                table: "ExpenseMembers");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseMembers_Expenses_ExpenseId",
                table: "ExpenseMembers",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id");
        }
    }
}
