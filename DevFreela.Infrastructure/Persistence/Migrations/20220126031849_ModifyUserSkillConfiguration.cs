using Microsoft.EntityFrameworkCore.Migrations;

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    public partial class ModifyUserSkillConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Skills_SkillId",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Users_IdSkill",
                table: "UserSkills");

            migrationBuilder.DropIndex(
                name: "IX_UserSkills_IdSkill",
                table: "UserSkills");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "UserSkills",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                newName: "IX_UserSkills_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_IdUser",
                table: "UserSkills",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Skills_IdUser",
                table: "UserSkills",
                column: "IdUser",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Users_UserId",
                table: "UserSkills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Skills_IdUser",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Users_UserId",
                table: "UserSkills");

            migrationBuilder.DropIndex(
                name: "IX_UserSkills_IdUser",
                table: "UserSkills");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserSkills",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_UserId",
                table: "UserSkills",
                newName: "IX_UserSkills_SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_IdSkill",
                table: "UserSkills",
                column: "IdSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Skills_SkillId",
                table: "UserSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Users_IdSkill",
                table: "UserSkills",
                column: "IdSkill",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
