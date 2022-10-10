using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class add_contact_table2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_users_FollowerUserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_users_FollowingUserId",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_FollowingUserId",
                table: "contacts",
                newName: "IX_contacts_FollowingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_FollowerUserId",
                table: "contacts",
                newName: "IX_contacts_FollowerUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts",
                table: "contacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_users_FollowerUserId",
                table: "contacts",
                column: "FollowerUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_users_FollowingUserId",
                table: "contacts",
                column: "FollowingUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_users_FollowerUserId",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_users_FollowingUserId",
                table: "contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts",
                table: "contacts");

            migrationBuilder.RenameTable(
                name: "contacts",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_contacts_FollowingUserId",
                table: "Contact",
                newName: "IX_Contact_FollowingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_contacts_FollowerUserId",
                table: "Contact",
                newName: "IX_Contact_FollowerUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_users_FollowerUserId",
                table: "Contact",
                column: "FollowerUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_users_FollowingUserId",
                table: "Contact",
                column: "FollowingUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
