using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookbookApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    TagID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeID = table.Column<string>(nullable: false),
                    SavedRecipe = table.Column<byte[]>(nullable: true),
                    DateSaved = table.Column<DateTime>(nullable: false),
                    AppliedTagsTagID = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeID);
                    table.ForeignKey(
                        name: "FK_Recipes_tags_AppliedTagsTagID",
                        column: x => x.AppliedTagsTagID,
                        principalTable: "tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_user_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accessFrequency",
                columns: table => new
                {
                    AccessfrequencyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeID = table.Column<string>(nullable: true),
                    DateLastAccessed = table.Column<DateTime>(nullable: false),
                    TimesAccessed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accessFrequency", x => x.AccessfrequencyID);
                    table.ForeignKey(
                        name: "FK_accessFrequency_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accessFrequency_RecipeID",
                table: "accessFrequency",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AppliedTagsTagID",
                table: "Recipes",
                column: "AppliedTagsTagID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserID",
                table: "Recipes",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accessFrequency");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
